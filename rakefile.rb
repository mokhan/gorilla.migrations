require 'build_utilities.rb'
require 'local_properties.rb'
require 'project.rb'
require 'rake/clean'
require 'fileutils'

#load settings that differ by machine
local_settings = LocalSettings.new

if local_settings[:debug] == "TRUE"
	COMPILE_TARGET = 'debug'
else
	COMPILE_TARGET = 'release'
end

CLEAN.include('artifacts','**/bin','**/obj')

def create_sql_fileset(folder)
  FileList.new(File.join('product','sql',folder,'**/*.sql'))
end

template_files = TemplateFileList.new('**/*.template')
template_code_dir = File.join('product','templated_code')

#configuration files
config_files = FileList.new(File.join('product','config','*.template')).select{|fn| ! fn.include?('app.config')}
app_config = TemplateFile.new(File.join('product','config',local_settings[:app_config_template]))

#target folders that can be run from VS
project_startup_dir  = File.join('product',"#{Project.startup_dir}")
project_test_dir  = File.join('product',"#{Project.tests_dir}",'bin','debug')

output_folders = [project_startup_dir,project_test_dir]

task :default => [:test]

task :clean do
	FileUtils.rm_rf('artifacts')
end

task :init => :clean do
  mkdir 'artifacts'
  mkdir 'artifacts/coverage'
  mkdir 'artifacts/deploy'
  mkdir "artifacts/deploy/#{Project.name}"
end

task :compile do
  MSBuildRunner.compile :compile_target => COMPILE_TARGET, :solution_file => 'solution.sln'
end

task :test, :category_to_exclude, :needs => [:compile] do |t,args|
  runner = MbUnitRunner.new :compile_target => COMPILE_TARGET, :category_to_exclude => 'SLOW', :show_report => true, :report_type => "text"
  runner.execute_tests ["#{Project.tests_dir}"]
end

task :test_xml, :category_to_exclude, :needs => [:compile] do |t,args|
  runner = MbUnitRunner.new :compile_target => COMPILE_TARGET, :category_to_exclude => 'SLOW'
  runner.execute_tests ["#{Project.tests_dir}"]
end

task :test_all, :category_to_exclude, :needs => [:compile] do |t,args|
  runner = MbUnitRunner.new :compile_target => COMPILE_TARGET, :category_to_exclude => 'none', :show_report => true, :report_type => "text"
  runner.execute_tests ["#{Project.tests_dir}"]
end

task :info do
	puts "project name: " + Project.name
	puts "project tests dir: " + Project.tests_dir
	puts "project startup dir: " + Project.startup_dir
	puts "project startup config: " + Project.startup_config
	puts "project startup extension: " + Project.startup_extension
	puts COMPILE_TARGET
end

task :run_test_report => [:test_xml] do
 runner = BDDDocRunner.new
 runner.run(File.join('product',"#{Project.tests_dir}",'bin','debug',"application.tests.dll"))
end

task :deploy => [:init,:compile] do
  deploy_folder = File.join('artifacts','deploy')
  copy_project_outputs(File.join(deploy_folder,Project.name),['*.dll','*.exe','*.pdb'])
  FileUtils.cp_r(File.join('thirdparty','mbunit'),deploy_folder)
  FileUtils.cp_r(File.join('thirdparty','rhino.mocks'),deploy_folder)
  FileUtils.cp_r(File.join('thirdparty','developwithpassion.commons'),deploy_folder)
end

task :run do
	deploy_folder = File.join('artifacts','deploy')
	sql_folder = File.join(Dir.getwd,'product','sql')
	command_line = "\"-migrations_dir:'#{sql_folder}' -connection_string:'#{local_settings[:config_connectionstring]}' -data_provider:'System.Data.SqlClient'\""
	sh "#{deploy_folder}/#{Project.name}/#{Project.name}.console.exe '#{command_line}'"
end

def copy_project_outputs(folder,extensions)
  extensions.each do |extension|
	puts "#{Project.name}#{extension}"
    Dir.glob(File.join('product','**',"#{Project.name}#{extension}")).each do |file|
      FileUtils.cp file,folder
    end
  end
end

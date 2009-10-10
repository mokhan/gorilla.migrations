class Project
  attr_reader :name 
  attr_reader :startup_dir 
  attr_reader :tests_dir 
  attr_reader :startup_config
  attr_reader :startup_extension

  def self.name
    @name = "gorilla.migrations"
  end

  def self.startup_dir
    @startup_dir = "#{self.name}"
  end

  def self.tests_dir
    #@tests_dir = "test.#{self.name}"
    @tests_dir = "application.tests"
  end

  def self.startup_config
    @startup_config = "app.config"
  end

  def self.startup_extension
    @startup_extension = ".dll"
  end

end

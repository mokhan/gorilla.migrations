USE [master]
GO

IF EXISTS(SELECT * FROM Sysdatabases WHERE NAME LIKE 'gorilla')
  DROP DATABASE [gorilla]
  GO

CREATE DATABASE [nothinbutdotnetprep] ON  PRIMARY 
( NAME = N'gorilla', FILENAME = N'd:\databases\gorilla.mdf' , SIZE = 2240KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'gorilla_log', FILENAME = N'd:\databases\gorilla.ldf' , SIZE = 768KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

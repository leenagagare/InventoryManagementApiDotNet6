create database Inventory_Management


CREATE TABLE [dbo].[product_master](
	[pm_product_code] [int] IDENTITY(100,1) NOT NULL ,
	[pm_name] [varchar](100) NULL,
	[pm_description]  [varchar](255) NULL,
	[pm_price] [decimal](8, 2) NULL,
) 

drop table [product_master]
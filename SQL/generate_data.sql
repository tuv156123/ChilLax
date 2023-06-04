USE [ChilLax]
DECLARE @return_value int

--清空資料表
TRUNCATE TABLE dbo.PRODUCT_ORDER ;
TRUNCATE TABLE dbo.ORDERDETAIL ;
TRUNCATE TABLE dbo.PURCHASE ;
TRUNCATE TABLE dbo.PURCHASEDETAIL ;
--創建商品訂單及商品請購單 10000比商品訂單 60比商品請購單
EXEC	 [dbo].[sp_generate_order] 10000;
EXEC	 [dbo].[sp_generate_purchase] 60;
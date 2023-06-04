--程式化語法產生多筆 Purchase 與 PurchaseDetail 資料
--設定產生比數變數為@data_row 由新增語法貼上 EXEC [dbo].[sp_generate_order] data_row; 執行
--此檔案存入 procedures(預存程序) 呼叫執行
CREATE PROCEDURE dbo.sp_generate_purchase (@data_row int = 1)AS 

DECLARE @supplier_id INT;
DECLARE @purchase_note NVARCHAR(MAX);
DECLARE @purchase_date DATETIME;
DECLARE @product_id int;
DECLARE @purchase_quantity int;
DECLARE @purchase_price int;

DECLARE @counter INT = 1;

WHILE @counter <= @data_row
BEGIN
    SET @supplier_id = (SELECT TOP 1 supplier_id FROM SUPPLIER ORDER BY NEWID());
    
    SET @purchase_note = '這是第 ' + CAST(@counter AS NVARCHAR(2)) + ' 比假資料'; 

    SET @purchase_date = DATEADD(DAY, @counter - 1, '2022-12-25');
    
    INSERT INTO [dbo].[Purchase] ([supplier_id], [purchase_note], [purchase_date])
    VALUES (@supplier_id, @purchase_note, @purchase_date);
--------------------------------------------存入請購單詳細資料表--------------------------------------
    SET @product_id = (SELECT TOP 1 PRODUCT_ID
					  FROM PRODUCT P
					  INNER JOIN SUPPLIER S ON P.SUPPLIER_ID = S.SUPPLIER_ID
					  WHERE S.SUPPLIER_ID = @supplier_id);

	SET @purchase_quantity = (FLOOR(RAND() * 10) + 1) * 10;

	SET @purchase_price = (SELECT p.PRODUCT_PRICE  FROM dbo.PRODUCT P WHERE p.PRODUCT_ID = @product_id) / 2;

	INSERT INTO ChilLax.dbo.PurchaseDetail
	(purchase_id, product_id, purchase_quantity, purchase_price)
	VALUES( 
			@@IDENTITY,
			@product_id,
			@purchase_quantity,
			@purchase_price
	);
	


    
    SET @counter = @counter + 1;
END;
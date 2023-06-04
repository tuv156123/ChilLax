--程式化語法產生多筆 product_order 與 OrderDetail 資料
--設定產生比數變數為@data_row 由新增語法貼上 EXEC [dbo].[sp_generate_order] data_row; 執行
--此檔案存入 procedures(預存程序) 呼叫執行
CREATE PROCEDURE dbo.sp_generate_order(@data_row int = 1) AS 

DECLARE @counter INT;
DECLARE @order_totalPrice INT;
DECLARE @member_id INT;
DECLARE @order_delivery BIT;
DECLARE @cityList NVARCHAR(500);
DECLARE @order_address NVARCHAR(max);	
DECLARE @order_payment BIT;
DECLARE @order_note NVARCHAR(max);
DECLARE @order_date DATETIME;
DECLARE @order_state NVARCHAR(500);

DECLARE @order_detail_row INT;
DECLARE @temp_order_detail TABLE (
    product_id int,
    qty int,
    product_price int
);

SET @counter = 1;

WHILE (@counter <= @data_row)
BEGIN
	
	--先產生 order detail 資料才能計算總價
	SET @order_detail_row = FLOOR(RAND() * 5) + 1;

	INSERT INTO @temp_order_detail (
		product_id,
		qty,
		product_price
	)
	SELECT
		product_id,
		qty,
		product_price
	FROM (
		SELECT TOP (@order_detail_row)
			product_id,
			(FLOOR(RAND() * 3) + 1) as qty,
			product_price
		FROM dbo.Product p
		ORDER BY NEWID()
	) a;
	-- order detail 資料存入臨時資料表
	SET
	@order_totalPrice = (
		SELECT sum( qty * product_price ) as total_price
		FROM @temp_order_detail
	);

	SET @member_id = FLOOR(RAND() * 9) + 1;
	
	SET @order_payment = CAST(RAND() * 2 AS BIT);
		
	SET @order_delivery = CAST(RAND() * 2 AS BIT);
	
	SET @cityList = '台北市,新北市,桃園市,台中市,台南市,高雄市,宜蘭縣,新竹縣,苗栗縣,彰化縣,南投縣,雲林縣,嘉義縣,屏東縣,花蓮縣,台東縣,澎湖縣,基隆市,新竹市,嘉義市';
		
	SET @order_address = (
		SELECT TOP 1 value
		FROM STRING_SPLIT(@cityList, ',')
		ORDER BY NEWID()
	);
		
	SET @order_date = DATEADD(day, -CAST(RAND() * 485 AS INT), GETDATE());
		
	SET @order_note = (
	    CASE
			WHEN CAST(RAND() * 100 AS INT) < 50 THEN '隨意的備註內容'
			ELSE NULL
		END
	);
	
	SET @order_state = (
	    CASE
			WHEN @order_date < '2023-05-15' THEN '已完成'
			WHEN @order_date < '2023-05-30' THEN '已出貨'
			ELSE '未出貨'
		END
	);
	
	INSERT INTO ChilLax.dbo.product_order(
		member_id, 
		payment, 
		totalPrice, 
		delivery, 
		address, 
		update_time, 
		note, 
		state
	)
	VALUES(
		@member_id, 
		@order_payment, 
		@order_totalPrice, 	
		@order_delivery, 
		@order_address, 
		@order_date, 
		@order_note, 
		@order_state
	);
	
	SET	@counter = @counter + 1;
	
	INSERT INTO ChilLax.dbo.OrderDetail(
		order_id,
		product_id,
		order_product_quantity
	)
	SELECT @@IDENTITY, product_id, qty FROM @temp_order_detail;
	delete from @temp_order_detail;

END;

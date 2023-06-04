USE [ChilLax]
GO
/****** Object:  Table [dbo].[Announcement]    Script Date: 2023/6/1 下午 04:32:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Announcement](
	[announcement_id] [int] IDENTITY(1,1) NOT NULL,
	[announcement] [nvarchar](1000) NOT NULL,
	[start_date] [date] NOT NULL,
	[end_date] [date] NOT NULL,
	[bonus_for_focus] [int] NOT NULL,
	[bonus_for_shopping] [int] NOT NULL,
 CONSTRAINT [PK_Announcement] PRIMARY KEY CLUSTERED 
(
	[announcement_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cart]    Script Date: 2023/6/1 下午 04:32:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cart](
	[member_id] [int] NOT NULL,
	[product_id] [int] IDENTITY(1,1) NOT NULL,
	[cart_product_quantity] [int] NOT NULL,
 CONSTRAINT [PK_Cart] PRIMARY KEY CLUSTERED 
(
	[member_id] ASC,
	[product_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 2023/6/1 下午 04:32:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[emp_id] [int] IDENTITY(1,1) NOT NULL,
	[emp_permission] [bit] NOT NULL,
	[emp_name] [nvarchar](50) NOT NULL,
	[emp_account] [nvarchar](50) NOT NULL,
	[emp_password] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[emp_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Focus]    Script Date: 2023/6/1 下午 04:32:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Focus](
	[focus_id] [int] IDENTITY(1,1) NOT NULL,
	[category] [nvarchar](100) NOT NULL,
	[image_path] [nvarchar](max) NOT NULL,
	[music_path] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Focus] PRIMARY KEY CLUSTERED 
(
	[focus_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Member]    Script Date: 2023/6/1 下午 04:32:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Member](
	[member_id] [int] IDENTITY(1,1) NOT NULL,
	[member_name] [nvarchar](50) NOT NULL,
	[member_tel] [varchar](50) NOT NULL,
	[member_address] [nvarchar](100) NULL,
	[member_email] [nvarchar](50) NOT NULL,
	[member_birthday] [date] NOT NULL,
	[member_sex] [bit] NULL,
	[member_point] [int] NULL,
	[member_joinTime] [datetime] NOT NULL,
 CONSTRAINT [PK_Members] PRIMARY KEY CLUSTERED 
(
	[member_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MemberCredential]    Script Date: 2023/6/1 下午 04:32:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MemberCredential](
	[member_id] [int] IDENTITY(1,1) NOT NULL,
	[member_account] [nvarchar](50) NOT NULL,
	[member_password] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_MemberCredential] PRIMARY KEY CLUSTERED 
(
	[member_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MemberService]    Script Date: 2023/6/1 下午 04:32:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MemberService](
	[member_service_ID] [int] NOT NULL,
	[member_ID] [int] IDENTITY(1,1) NOT NULL,
	[message] [nvarchar](max) NOT NULL,
	[reply] [nvarchar](max) NOT NULL,
	[message_datetime] [datetime] NOT NULL,
	[reply_datetime] [datetime] NOT NULL,
 CONSTRAINT [PK_MemberService] PRIMARY KEY CLUSTERED 
(
	[member_service_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 2023/6/1 下午 04:32:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[order_id] [int] IDENTITY(1,1) NOT NULL,
	[member_id] [int] NOT NULL,
	[order_payment] [bit] NOT NULL,
	[order_totalPrice] [int] NOT NULL,
	[order_delivery] [bit] NOT NULL,
	[order_address] [nvarchar](max) NOT NULL,
	[order_date] [datetime] NOT NULL,
	[order_note] [nvarchar](max) NULL,
	[order_state] [nvarchar](500) NOT NULL,
	[point_detail_id] [int] NOT NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[order_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 2023/6/1 下午 04:32:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[order_id] [int] NOT NULL,
	[product_id] [int] NOT NULL,
	[order_product_quantity] [int] NULL,
 CONSTRAINT [PK_OrderDetail] PRIMARY KEY CLUSTERED 
(
	[order_id] ASC,
	[product_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PointDetail]    Script Date: 2023/6/1 下午 04:32:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PointDetail](
	[point_detail_id] [int] NOT NULL,
	[member_id] [int] NOT NULL,
	[modified_datetime] [datetime] NOT NULL,
	[modified_by] [nvarchar](100) NOT NULL,
	[modified_amount] [int] NOT NULL,
 CONSTRAINT [PK_PointDetail] PRIMARY KEY CLUSTERED 
(
	[point_detail_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 2023/6/1 下午 04:32:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[product_id] [int] IDENTITY(1,1) NOT NULL,
	[supplier_id] [int] NOT NULL,
	[product_name] [nvarchar](100) NOT NULL,
	[product_desc] [nvarchar](max) NOT NULL,
	[product_price] [int] NOT NULL,
	[product_img] [nvarchar](50) NOT NULL,
	[product_inventory] [int] NOT NULL,
	[product_category] [nvarchar](50) NOT NULL,
	[product_state] [bit] NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[product_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Purchase]    Script Date: 2023/6/1 下午 04:32:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Purchase](
	[purchase_id] [int] IDENTITY(1,1) NOT NULL,
	[supplier_id] [int] NOT NULL,
	[purchase_note] [nvarchar](max) NULL,
	[purchase_date] [datetime] NOT NULL,
 CONSTRAINT [PK_OrderProduct] PRIMARY KEY CLUSTERED 
(
	[purchase_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PurchaseDetail]    Script Date: 2023/6/1 下午 04:32:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurchaseDetail](
	[purchase_id] [int] IDENTITY(1,1) NOT NULL,
	[product_id] [int] NOT NULL,
	[purchase_quantity] [int] NOT NULL,
	[purchase_price] [int] NOT NULL,
 CONSTRAINT [PK_OrderProductDetail] PRIMARY KEY CLUSTERED 
(
	[purchase_id] ASC,
	[product_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Supplier]    Script Date: 2023/6/1 下午 04:32:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Supplier](
	[supplier_id] [int] IDENTITY(1,1) NOT NULL,
	[supplier_name] [nvarchar](500) NOT NULL,
	[supplier_tel] [nvarchar](50) NOT NULL,
	[supplier_address] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Supplier] PRIMARY KEY CLUSTERED 
(
	[supplier_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TarotCard]    Script Date: 2023/6/1 下午 04:32:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TarotCard](
	[tarotCard_ID] [int] NOT NULL,
	[tarotCard_name] [nvarchar](50) NOT NULL,
	[tarotCard_type] [nchar](10) NOT NULL,
 CONSTRAINT [PK_TarotCard] PRIMARY KEY CLUSTERED 
(
	[tarotCard_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TarotOrder]    Script Date: 2023/6/1 下午 04:32:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TarotOrder](
	[tarotOrder_ID] [int] NOT NULL,
	[member_ID] [int] NOT NULL,
	[card_result] [nvarchar](50) NOT NULL,
	[divination_chat] [nvarchar](max) NOT NULL,
	[point_detail_id] [int] NOT NULL,
 CONSTRAINT [PK_TarotOrder] PRIMARY KEY CLUSTERED 
(
	[tarotOrder_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Cart]  WITH CHECK ADD  CONSTRAINT [FK_Cart_Member] FOREIGN KEY([member_id])
REFERENCES [dbo].[Member] ([member_id])
GO
ALTER TABLE [dbo].[Cart] CHECK CONSTRAINT [FK_Cart_Member]
GO
ALTER TABLE [dbo].[Cart]  WITH CHECK ADD  CONSTRAINT [FK_Cart_Product] FOREIGN KEY([product_id])
REFERENCES [dbo].[Product] ([product_id])
GO
ALTER TABLE [dbo].[Cart] CHECK CONSTRAINT [FK_Cart_Product]
GO
ALTER TABLE [dbo].[MemberCredential]  WITH CHECK ADD  CONSTRAINT [FK_MemberCredential_Member] FOREIGN KEY([member_id])
REFERENCES [dbo].[Member] ([member_id])
GO
ALTER TABLE [dbo].[MemberCredential] CHECK CONSTRAINT [FK_MemberCredential_Member]
GO
ALTER TABLE [dbo].[MemberService]  WITH CHECK ADD  CONSTRAINT [FK_MemberService_Member] FOREIGN KEY([member_ID])
REFERENCES [dbo].[Member] ([member_id])
GO
ALTER TABLE [dbo].[MemberService] CHECK CONSTRAINT [FK_MemberService_Member]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_Member] FOREIGN KEY([order_id])
REFERENCES [dbo].[Member] ([member_id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_Member]
GO
ALTER TABLE [dbo].[Order]  WITH CHECK ADD  CONSTRAINT [FK_Order_PointDetail] FOREIGN KEY([point_detail_id])
REFERENCES [dbo].[PointDetail] ([point_detail_id])
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_PointDetail]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_Order] FOREIGN KEY([order_id])
REFERENCES [dbo].[Order] ([order_id])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_Order]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH CHECK ADD  CONSTRAINT [FK_OrderDetail_Product] FOREIGN KEY([product_id])
REFERENCES [dbo].[Product] ([product_id])
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_Product]
GO
ALTER TABLE [dbo].[PointDetail]  WITH CHECK ADD  CONSTRAINT [FK_PointDetail_Member] FOREIGN KEY([point_detail_id])
REFERENCES [dbo].[Member] ([member_id])
GO
ALTER TABLE [dbo].[PointDetail] CHECK CONSTRAINT [FK_PointDetail_Member]
GO
ALTER TABLE [dbo].[Product]  WITH CHECK ADD  CONSTRAINT [FK_Product_Supplier] FOREIGN KEY([supplier_id])
REFERENCES [dbo].[Supplier] ([supplier_id])
GO
ALTER TABLE [dbo].[Product] CHECK CONSTRAINT [FK_Product_Supplier]
GO
ALTER TABLE [dbo].[Purchase]  WITH CHECK ADD  CONSTRAINT [FK_Purchase_Supplier] FOREIGN KEY([purchase_id])
REFERENCES [dbo].[Supplier] ([supplier_id])
GO
ALTER TABLE [dbo].[Purchase] CHECK CONSTRAINT [FK_Purchase_Supplier]
GO
ALTER TABLE [dbo].[PurchaseDetail]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseDetail_Product] FOREIGN KEY([product_id])
REFERENCES [dbo].[Product] ([product_id])
GO
ALTER TABLE [dbo].[PurchaseDetail] CHECK CONSTRAINT [FK_PurchaseDetail_Product]
GO
ALTER TABLE [dbo].[PurchaseDetail]  WITH CHECK ADD  CONSTRAINT [FK_PurchaseDetail_Purchase] FOREIGN KEY([purchase_id])
REFERENCES [dbo].[Purchase] ([purchase_id])
GO
ALTER TABLE [dbo].[PurchaseDetail] CHECK CONSTRAINT [FK_PurchaseDetail_Purchase]
GO
ALTER TABLE [dbo].[TarotOrder]  WITH CHECK ADD  CONSTRAINT [FK_TarotOrder_Member] FOREIGN KEY([member_ID])
REFERENCES [dbo].[Member] ([member_id])
GO
ALTER TABLE [dbo].[TarotOrder] CHECK CONSTRAINT [FK_TarotOrder_Member]
GO
ALTER TABLE [dbo].[TarotOrder]  WITH CHECK ADD  CONSTRAINT [FK_TarotOrder_PointDetail] FOREIGN KEY([tarotOrder_ID])
REFERENCES [dbo].[PointDetail] ([point_detail_id])
GO
ALTER TABLE [dbo].[TarotOrder] CHECK CONSTRAINT [FK_TarotOrder_PointDetail]
GO

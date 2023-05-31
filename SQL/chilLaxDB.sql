USE [ChilLax]
GO
/****** Object:  Table [dbo].[Announcement]    Script Date: 2023/5/31 上午 12:02:23 ******/
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
/****** Object:  Table [dbo].[Cart]    Script Date: 2023/5/31 上午 12:02:23 ******/
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
/****** Object:  Table [dbo].[Employee]    Script Date: 2023/5/31 上午 12:02:23 ******/
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
/****** Object:  Table [dbo].[Focus]    Script Date: 2023/5/31 上午 12:02:23 ******/
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
/****** Object:  Table [dbo].[Member]    Script Date: 2023/5/31 上午 12:02:23 ******/
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
/****** Object:  Table [dbo].[MemberCredential]    Script Date: 2023/5/31 上午 12:02:23 ******/
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
/****** Object:  Table [dbo].[MemberService]    Script Date: 2023/5/31 上午 12:02:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MemberService](
	[member_service_ID] [int] NOT NULL,
	[member_ID] [int] NOT NULL,
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
/****** Object:  Table [dbo].[Order]    Script Date: 2023/5/31 上午 12:02:23 ******/
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
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[order_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 2023/5/31 上午 12:02:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[order_id] [int] NOT NULL,
	[product_id] [int] IDENTITY(1,1) NOT NULL,
	[cart_product_quantity] [int] NOT NULL,
 CONSTRAINT [PK_OrderDetail] PRIMARY KEY CLUSTERED 
(
	[order_id] ASC,
	[product_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderProduct]    Script Date: 2023/5/31 上午 12:02:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderProduct](
	[order_product_id] [int] IDENTITY(1,1) NOT NULL,
	[supplier_id] [int] NOT NULL,
	[order_product_note] [nvarchar](max) NULL,
	[order_product_date] [datetime] NOT NULL,
 CONSTRAINT [PK_OrderProduct] PRIMARY KEY CLUSTERED 
(
	[order_product_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderProductDetail]    Script Date: 2023/5/31 上午 12:02:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderProductDetail](
	[order_product_id] [int] IDENTITY(1,1) NOT NULL,
	[product_id] [int] NOT NULL,
	[order_product_quantity] [int] NOT NULL,
	[order_product_price] [int] NOT NULL,
 CONSTRAINT [PK_OrderProductDetail] PRIMARY KEY CLUSTERED 
(
	[order_product_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 2023/5/31 上午 12:02:23 ******/
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
	[product_quantity] [int] NOT NULL,
	[product_type] [nvarchar](50) NOT NULL,
	[product_state] [bit] NOT NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[product_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Supplier]    Script Date: 2023/5/31 上午 12:02:23 ******/
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
/****** Object:  Table [dbo].[TarotCard]    Script Date: 2023/5/31 上午 12:02:23 ******/
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
/****** Object:  Table [dbo].[TarotOrder]    Script Date: 2023/5/31 上午 12:02:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TarotOrder](
	[tarotOrder_ID] [int] NOT NULL,
	[member_ID] [int] NOT NULL,
	[card_result] [nvarchar](50) NOT NULL,
	[divination_chat] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_TarotOrder] PRIMARY KEY CLUSTERED 
(
	[tarotOrder_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Announcement] ON 

INSERT [dbo].[Announcement] ([announcement_id], [announcement], [start_date], [end_date], [bonus_for_focus], [bonus_for_shopping]) VALUES (1, N'為了提升使用者體驗，我們將於三日後6/1(四)進行網站更新，不便之處敬請見諒', CAST(N'2023-05-29' AS Date), CAST(N'2023-06-01' AS Date), 1, 1)
INSERT [dbo].[Announcement] ([announcement_id], [announcement], [start_date], [end_date], [bonus_for_focus], [bonus_for_shopping]) VALUES (2, N'祝福敬愛的網友們端午節快樂，本週點數雙倍大放送', CAST(N'2023-06-19' AS Date), CAST(N'2023-06-25' AS Date), 2, 2)
INSERT [dbo].[Announcement] ([announcement_id], [announcement], [start_date], [end_date], [bonus_for_focus], [bonus_for_shopping]) VALUES (3, N'端午連假6/22(四)~6/25(日)暫停出貨', CAST(N'2023-06-22' AS Date), CAST(N'2023-06-25' AS Date), 1, 1)
INSERT [dbo].[Announcement] ([announcement_id], [announcement], [start_date], [end_date], [bonus_for_focus], [bonus_for_shopping]) VALUES (4, N'最近詐騙集團猖獗，有多家網路平台陸續受害，請大家務必提高警覺小心受騙', CAST(N'2023-06-01' AS Date), CAST(N'2023-12-31' AS Date), 1, 1)
INSERT [dbo].[Announcement] ([announcement_id], [announcement], [start_date], [end_date], [bonus_for_focus], [bonus_for_shopping]) VALUES (5, N'專注頁面已推出新音效，歡迎前往體驗', CAST(N'2023-06-23' AS Date), CAST(N'2023-06-25' AS Date), 1, 1)
INSERT [dbo].[Announcement] ([announcement_id], [announcement], [start_date], [end_date], [bonus_for_focus], [bonus_for_shopping]) VALUES (6, N'療育商城多項商品促銷中，歡迎前往選購', CAST(N'2023-07-01' AS Date), CAST(N'2023-08-31' AS Date), 1, 1)
SET IDENTITY_INSERT [dbo].[Announcement] OFF
GO
SET IDENTITY_INSERT [dbo].[Employee] ON 

INSERT [dbo].[Employee] ([emp_id], [emp_permission], [emp_name], [emp_account], [emp_password]) VALUES (1, 1, N'李君均', N'junjun@yyaa.com.tw', N'0925-987634')
INSERT [dbo].[Employee] ([emp_id], [emp_permission], [emp_name], [emp_account], [emp_password]) VALUES (2, 0, N'蔡佩珊', N'caipeishan@gmail.com', N'0989-012345')
INSERT [dbo].[Employee] ([emp_id], [emp_permission], [emp_name], [emp_account], [emp_password]) VALUES (3, 0, N'周俊宏', N'zhoujunhong@yahoo.com.tw', N'0947-890123')
INSERT [dbo].[Employee] ([emp_id], [emp_permission], [emp_name], [emp_account], [emp_password]) VALUES (4, 0, N'楊春妍', N'yangchunyan@outlook.com', N'0935-678901')
SET IDENTITY_INSERT [dbo].[Employee] OFF
GO
SET IDENTITY_INSERT [dbo].[Focus] ON 

INSERT [dbo].[Focus] ([focus_id], [category], [image_path], [music_path]) VALUES (1, N'海浪', N'wave.jpg', N'wave.mp3')
INSERT [dbo].[Focus] ([focus_id], [category], [image_path], [music_path]) VALUES (2, N'森林', N'forest.jpg', N'forest.mp3')
INSERT [dbo].[Focus] ([focus_id], [category], [image_path], [music_path]) VALUES (3, N'柴火', N'fire.jpg', N'fire.mp3')
INSERT [dbo].[Focus] ([focus_id], [category], [image_path], [music_path]) VALUES (4, N'雨天', N'rain.jpg', N'rain.mp3')
INSERT [dbo].[Focus] ([focus_id], [category], [image_path], [music_path]) VALUES (5, N'風鈴', N'windchime.jpg', N'windchime.mp3')
SET IDENTITY_INSERT [dbo].[Focus] OFF
GO
SET IDENTITY_INSERT [dbo].[Member] ON 

INSERT [dbo].[Member] ([member_id], [member_name], [member_tel], [member_address], [member_email], [member_birthday], [member_sex], [member_point], [member_joinTime]) VALUES (1, N'林小雯', N'0923-456789', N'宜蘭縣礁溪鄉', N'linxiaowen@gmail.com', CAST(N'1988-01-05' AS Date), 0, 0, CAST(N'2023-05-30T15:00:01.000' AS DateTime))
INSERT [dbo].[Member] ([member_id], [member_name], [member_tel], [member_address], [member_email], [member_birthday], [member_sex], [member_point], [member_joinTime]) VALUES (2, N'張大為', N'0938-234567', N'嘉義縣水上鄉', N'zhangdawei@hotmail.com', CAST(N'1989-05-14' AS Date), 1, 0, CAST(N'2023-05-30T16:12:25.000' AS DateTime))
INSERT [dbo].[Member] ([member_id], [member_name], [member_tel], [member_address], [member_email], [member_birthday], [member_sex], [member_point], [member_joinTime]) VALUES (3, N'陳婉如', N'0987-345678', N'台南市仁德區', N'chenwanru@yahoo.com.tw', CAST(N'1994-12-28' AS Date), 0, 0, CAST(N'2023-05-30T18:46:31.000' AS DateTime))
INSERT [dbo].[Member] ([member_id], [member_name], [member_tel], [member_address], [member_email], [member_birthday], [member_sex], [member_point], [member_joinTime]) VALUES (4, N'王文彬', N'0988-987654', N'屏東縣三地門鄉', N'wangwenbin@gmail.com', CAST(N'1982-09-18' AS Date), 1, 0, CAST(N'2023-05-31T08:32:51.000' AS DateTime))
INSERT [dbo].[Member] ([member_id], [member_name], [member_tel], [member_address], [member_email], [member_birthday], [member_sex], [member_point], [member_joinTime]) VALUES (5, N'黃志明', N'0976-876543', N'新北市中和區', N'huangzhiming@outlook.com', CAST(N'1985-06-28' AS Date), 1, 0, CAST(N'2023-05-31T09:12:23.000' AS DateTime))
INSERT [dbo].[Member] ([member_id], [member_name], [member_tel], [member_address], [member_email], [member_birthday], [member_sex], [member_point], [member_joinTime]) VALUES (6, N'李佳璇', N'0965-567890', N'', N'lijiaxuan@yahoo.com', CAST(N'1993-11-23' AS Date), 0, 0, CAST(N'2023-05-31T11:12:42.000' AS DateTime))
INSERT [dbo].[Member] ([member_id], [member_name], [member_tel], [member_address], [member_email], [member_birthday], [member_sex], [member_point], [member_joinTime]) VALUES (7, N'吳俊偉', N'0988-654321', N'彰化縣和美鎮', N'wujunwei@gmail.com', CAST(N'1992-06-24' AS Date), 1, 0, CAST(N'2023-05-31T15:45:33.000' AS DateTime))
INSERT [dbo].[Member] ([member_id], [member_name], [member_tel], [member_address], [member_email], [member_birthday], [member_sex], [member_point], [member_joinTime]) VALUES (8, N'鄭美玲', N'0945-345678', N'南投縣草屯鎮', N'zhengmeiling@msn.com', CAST(N'1991-04-29' AS Date), 0, 0, CAST(N'2023-05-31T18:16:39.000' AS DateTime))
INSERT [dbo].[Member] ([member_id], [member_name], [member_tel], [member_address], [member_email], [member_birthday], [member_sex], [member_point], [member_joinTime]) VALUES (9, N'許明展', N'0928-789012', NULL, N'xumingzhan@hotmail.com', CAST(N'1998-05-17' AS Date), NULL, NULL, CAST(N'2023-06-01T08:42:36.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Member] OFF
GO
SET IDENTITY_INSERT [dbo].[MemberCredential] ON 

INSERT [dbo].[MemberCredential] ([member_id], [member_account], [member_password]) VALUES (1, N'linxiaowen0105', N'xiaowen0923456789')
INSERT [dbo].[MemberCredential] ([member_id], [member_account], [member_password]) VALUES (2, N'zhangdawei0514', N'dawei0938234567')
INSERT [dbo].[MemberCredential] ([member_id], [member_account], [member_password]) VALUES (3, N'chenwanru1228', N'wanru0987345678')
INSERT [dbo].[MemberCredential] ([member_id], [member_account], [member_password]) VALUES (4, N'wangwenbin0918', N'wenbin0988-987654')
INSERT [dbo].[MemberCredential] ([member_id], [member_account], [member_password]) VALUES (5, N'huangzhiming0628', N'zhiming0976876543')
INSERT [dbo].[MemberCredential] ([member_id], [member_account], [member_password]) VALUES (6, N'lijiaxuan1123', N'jiaxuan0965567890')
INSERT [dbo].[MemberCredential] ([member_id], [member_account], [member_password]) VALUES (7, N'wujunwei0624', N'junwei0988654321')
INSERT [dbo].[MemberCredential] ([member_id], [member_account], [member_password]) VALUES (8, N'zhengmeiling0429', N'meiling0429')
INSERT [dbo].[MemberCredential] ([member_id], [member_account], [member_password]) VALUES (9, N'xumingzhan0517', N'mingzhan0928789012')
SET IDENTITY_INSERT [dbo].[MemberCredential] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([product_id], [supplier_id], [product_name], [product_desc], [product_price], [product_img], [product_quantity], [product_type], [product_state]) VALUES (2, 3, N'綠頭魚解壓玩具', N'【完美減壓禮物】健身拉伸玩具、動物減壓玩具適合大多數人緩解壓力和釋放情緒，非常適合辦公室、家庭、車站、特殊教育教室、理療室、感官室和旅行。送給男孩、女孩、成人、同學、同事的最美妙的生日禮物、聖誕禮物、萬聖節禮物和其他節日禮物。
【優質材料】安全無毒的乳膠材料，不會傷害您的皮膚或產生任何氣味。精美可愛的設計，深受遊戲愛好者的喜愛。
【創意禮物】它可以用作生日、情人節、周年紀念、兒童節、萬聖節、聖誕節、新年等日常禮物，也可以作為自己的禮物。非常適合展示和收藏。每個收到禮物的人都會喜歡它。
【多種場合】放在臥室、客廳、家、辦公室、嬰兒床和任何您喜歡的花邊作為裝飾。
【設計靈感】獨特的設計和逼真的觸感，給你不一樣的視覺和感官體驗。
【易清潔】這款卡通玩具顏色鮮艷，易清潔，而且清潔起來非常簡單方便，給你最好的體驗，不用擔心。他們可愛的表情可以幫助你減輕壓力，讓你習慣它，讓你的家充滿愛和溫暖。
', 138, N'3.jpg', 150, N'紓壓小物', 1)
INSERT [dbo].[Product] ([product_id], [supplier_id], [product_name], [product_desc], [product_price], [product_img], [product_quantity], [product_type], [product_state]) VALUES (3, 4, N'解壓球', N'1.心情不好就使勁捏，釋放壓力。
2.物質無毒。
3.身邊總有一個愛生氣的朋友送他就對了。
4.超搞怪交換禮物，就你最特別。✨規格描述：
葡萄球捏捏勒 超解壓 全新色系 新鮮減壓球。
尺寸：約6cm。
特點：柔捏變形 慢回彈恢復。

', 98, N'4.jpg', 150, N'紓壓小物', 1)
INSERT [dbo].[Product] ([product_id], [supplier_id], [product_name], [product_desc], [product_price], [product_img], [product_quantity], [product_type], [product_state]) VALUES (4, 5, N'3D立體流沙畫小夜燈', N'【商品特色】
♦簡約百搭，可裝飾美家，靜心解壓，送禮佳品。
♦沙質細膩，畫面豐富，色彩清新明亮，令人賞心悅目，百看不膩，靜心解壓又治癒
♦高透亮材質，無鉛工藝，ABS底座設計，平穩安全。
♦可360度翻轉，每一次翻轉都有不一樣的美景。
《3D流沙畫》靜心解壓擺飾。
旋轉自然流動，畫面千變萬化。
每一次翻轉都是不同的風景。
享受流沙之幽美意境，送禮自用兩相宜‼
', 179, N'5.jpg', 80, N'擺飾裝飾', 1)
INSERT [dbo].[Product] ([product_id], [supplier_id], [product_name], [product_desc], [product_price], [product_img], [product_quantity], [product_type], [product_state]) VALUES (7, 6, N'水豚君擺飾裝飾', N'【一整組】
擁有可愛呆萌的外表
不管遇到甚麼事都非常淡定
還帶點小厭世的模樣
直接擄獲全世界芳心
養不起真的水豚沒關係
放一隻在辦公室療癒身心吧！
', 490, N'6.jpg', 70, N'擺飾裝飾', 1)
INSERT [dbo].[Product] ([product_id], [supplier_id], [product_name], [product_desc], [product_price], [product_img], [product_quantity], [product_type], [product_state]) VALUES (8, 2, N'泡泡樂 解壓玩具', N'材質：矽膠。
優點：培養認知能力/思維能力/心算訓練/預防腦力退化/統籌能力/釋放壓力。【注意事項】孩童使用時應有成人在場且應避免幼兒吞食窒息。
', 49, N'7.jpg、8.jpg、9.jpg', 150, N'紓壓小物', 1)
INSERT [dbo].[Product] ([product_id], [supplier_id], [product_name], [product_desc], [product_price], [product_img], [product_quantity], [product_type], [product_state]) VALUES (9, 5, N'舒壓按摩小物', N'臉部保養、全身放鬆一機搞定！
3D曲線導頭，刮痧無死角；
順臉拉提，打造小V臉；
溫熱導入，加速吸收；
冰鎮收斂，緊緻毛孔；
刮痧按摩，深入煥活；
穴道按摩，全身舒緩。
工作勞心勞神，肌膚還不聽話！
睡眠時間不足、連保養的時間都沒有。擁有這一台直接幫你放鬆身體保養肌膚！【產品規格】
溫度設定：42℃/12℃。 
電壓：DC 5V。
電池類型：鋰離子電池。
充電方式：Type-C充電。

', 2780, N'10.jpg、11.jpg', 70, N'按摩精油', 1)
INSERT [dbo].[Product] ([product_id], [supplier_id], [product_name], [product_desc], [product_price], [product_img], [product_quantity], [product_type], [product_state]) VALUES (10, 5, N'筋舒適 按摩小物', N'NULL專為忙碌的你設計－紓解壓力首選！
遠紅外線－按摩時能促進血液循環
熱水加溫－使用前浸水加熱更舒服
頭皮按摩－柔順凸點疏通頭皮經絡
輕鬆省力－握柄依據人體工學設計
清洗容易－滑順表面不易附著髒汙。【保養方式】
1.	可用清水或中性洗劑清洗，可放入洗碗機清洗
2.	沒使用時建議收於防塵袋妥善保存', 890, N'12.jpg', 100, N'按摩精油', 1)
INSERT [dbo].[Product] ([product_id], [supplier_id], [product_name], [product_desc], [product_price], [product_img], [product_quantity], [product_type], [product_state]) VALUES (11, 1, N'精油', N'品名：精油組(5mlx6)
✦ 產品介紹
適用 ▏卸下沉重壓力、調節神經系統、舒壓、改善睡眠品質

| 快樂鼠尾草 Clary Sage |
植物產地：保加利亞。

優雅愜意帶有茶香的快樂鼠尾草具有穩定身心的安撫力量，不僅可放鬆神經系統，也能一併梳理緊繃、糾結的心頭壓力，帶給人快樂舒壓的幸福感。

快樂鼠尾草對於婦科症狀也有卓越的舒緩效果，每當好朋友來訪時，不妨以它搭配腹部按摩，可減緩經期的不適，也能更香甜的入睡。

| 檸檬薄荷 Lemon Mint |
植物產地：印度。

| 甜羅勒 Sweet Basil |
植物產地：尼泊爾。

甜羅勒非常適合因疲勞導致精神狀態低落時使用，可以平撫焦慮、放鬆心情，幫身心充好電。也能讓轉動不停的大腦歇息，刪除雜念、緩解疲勞，給予安心寧靜的感覺。

| 廣藿香-特級 Patchouli, Extra |
植物產地：印尼

帶有泥土及中藥草香氣，給人一種無比踏實安心、寧靜的感受；廣藿香不僅氣味安撫人心，也具有很好的淨化防禦效果，可以添加在日常護膚保養品中，同時保護身體、滋潤心靈。

| 乳香-特級 Frankincense, Extra |
植物產地：索馬利亞。

被譽為最珍貴的精油之一，其香氣溫暖、帶有一些些辛辣，能讓人鎮定、放鬆，同時還帶來神聖的感受。

乳香精油除了能夠保養呼吸道，調整呼吸品質、使人的氣能順暢流動外，也特別適合處理急性感染和慢性長期累積的問題。由於生長在貧脊的環境，因此對於心靈層面遭遇艱苦的磨難與考驗時，能展現強韌的生命力與給予支持。若運用在護膚上，可幫助老化肌膚按捺小小細紋，是很不錯的回春保養品。

| 喀什米爾真正薰衣草 Kashmir Lavender |
植物產地：印度。
', 1850, N'13.jpg、14.jpg', 120, N'按摩精油', 1)
INSERT [dbo].[Product] ([product_id], [supplier_id], [product_name], [product_desc], [product_price], [product_img], [product_quantity], [product_type], [product_state]) VALUES (12, 1, N'香氛蠟燭', N'【商品特色】
[因為重視，所以我們用心看待
各各相似，卻不盡相同
浪漫香氛清新生活。
心靈療癒更勝千言萬語。
微小的火光，帶來無限的希望］。

>精油含量：10%以上。
>燃燒時間：40個小時左右。
>建議坪數：室內約5坪。⚠️使用注意事項⚠️
-本產品使用天然大豆蠟與純天然精油，
表面完全融化再熄滅，香味會自然從蠟液揮發出來。
-每次燃燒請等待液面完全融化在熄滅燭芯，以免燭芯周圍凹陷造成外圍大豆蠟無法正常融化。
-燃燒時，請遠離易燃物/寵物/孩童，並在穩固的檯面上使用，勿碰觸杯口以免燙傷 。
-本產品作用為輔助並非醫療用品，最重要的還是自身的改變。
-若使用時感到不適請立即停止使用。
', 879, N'15.jpg、16.jpg', 140, N'居家香氛', 1)
INSERT [dbo].[Product] ([product_id], [supplier_id], [product_name], [product_desc], [product_price], [product_img], [product_quantity], [product_type], [product_state]) VALUES (14, 3, N'史萊姆解壓玩具', N'【商品介紹】
零失誤史萊姆DIY手作組~
美國學校必做的專屬配方，
內含專業的史萊姆膠，
簡單步驟讓你成功做出史萊姆！

史萊姆是一種介於液態和固體之間的黏土，
延展性強，任你揉拉捏戳！
手感柔軟，QQ彈彈好抒壓~【注意事項】
1. 不可食用，請放置於3歲以下孩未不得取得處，避免誤食。
2. 7歲以下孩童請家長陪同操作。
3. 手捏史萊姆前及玩樂後，需使用肥皂或洗手乳清潔。
4. 操作時請避免沾到衣物，沾到後並不易去除，請立即使用肥皂清潔。
5. 一開始做好的史萊姆會很黏手，但放置容器中一天後，會較為適合戳揉玩樂。
6. 若手上有傷口，請勿觸碰史萊姆。
7. 玩完的史萊姆請放置在容器中保存，以免變乾或變質。
8. 若史萊姆開始有變質，請直接以垃圾丟棄。
', 380, N'17.jpg', 160, N'紓壓小物', 1)
INSERT [dbo].[Product] ([product_id], [supplier_id], [product_name], [product_desc], [product_price], [product_img], [product_quantity], [product_type], [product_state]) VALUES (15, 4, N'小奶龍解壓玩具', N'【商品特色】
奶黃色的身體，圓滾滾的身材，Q彈的手感～
任你怎麼蹂躪它都不投降
我擠、我捏、我壓
誒嘿，你能拿我怎麼著～
重壓之下，小奶龍永不屈服！
擺在桌面上，妥妥的栩栩如生的動態表情包
無聊時捏一捏，煩悶時抓一抓，難過時壓一壓拒絕內耗！ ！
小奶龍就是你的滿分情緒消化機！【注意事項】
1. 不可食用，請放置於3歲以下孩未不得取得處，避免誤食。
2. 7歲以下孩童請家長陪同操作。

', 145, N'18.jpg', 200, N'紓壓小物', 1)
INSERT [dbo].[Product] ([product_id], [supplier_id], [product_name], [product_desc], [product_price], [product_img], [product_quantity], [product_type], [product_state]) VALUES (16, 1, N'擴香石', N'提升滿滿幸福感的精緻小物。精緻的生活，可以是開心時送給自己的一束花。可以是閒暇時的一杯鮮榨果汁。可以是睡覺時的一個舒服眼罩。也可以是一杯既香又美的水晶石。能量改善磁場、讓您既香又好運。本產品不附精油，如需使水晶石擴香，可滴入自己喜愛的精油味道。
【商品規格】。
名稱：水晶擴香原石。
尺寸：底座長10cm、高2cm、內圈直徑92mm、USB開關線1.5米。
圓柱玻璃杯：底8.5 cm、高8 cm。
玻璃火三杯： 8.5cm(高度) x 9cm(寬度) 。
原石重量：400g (手工測量多少都有誤差, 都屬於正常現象) 。
功能：增加磁場轉運 / 裝飾擺件 / 香薰擺件。
', 599, N'1.jpg', 130, N'居家香氛', 1)
INSERT [dbo].[Product] ([product_id], [supplier_id], [product_name], [product_desc], [product_price], [product_img], [product_quantity], [product_type], [product_state]) VALUES (17, 2, N'療癒仙人掌擴香石', N'重量：約 130-150 g。
尺寸：約5.5 X 4.5 X 2 cm(仙人掌)、約5 X 4.1 cm (花盆)。
材料：高品質石膏、雲母石(裝飾用)。
*有色擴香石會因濕度、石膏礦物質、色料而有顏色不均或顏色變淺現象為正常。【購買須知】
擴香石製作完成後產生氣泡孔洞為自然現象不影響使用。
有色擴香石顏色會因為時間及陽光照射漸進褪色，為自然現象。
商品採接單才各別製作，請耐心等待或詢問寄出時間。
因為手工製作，同樣商品樣貌會有些許不同。

', 499, N'2.jpg', 160, N'居家香氛', 1)
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[Supplier] ON 

INSERT [dbo].[Supplier] ([supplier_id], [supplier_name], [supplier_tel], [supplier_address]) VALUES (1, N'賺大錢國際有限公司', N'0766863355', N'高雄市前金區中正四路211號8號樓之1')
INSERT [dbo].[Supplier] ([supplier_id], [supplier_name], [supplier_tel], [supplier_address]) VALUES (2, N'帝二化工原料股份有限公司', N'0296992559', N'台北市大同區天水路2號43樓')
INSERT [dbo].[Supplier] ([supplier_id], [supplier_name], [supplier_tel], [supplier_address]) VALUES (3, N'承緹企業社', N'073731337', N'高雄市仁武區仁孝路931號')
INSERT [dbo].[Supplier] ([supplier_id], [supplier_name], [supplier_tel], [supplier_address]) VALUES (4, N'彩虹陶藝工藝社', N'0226772312', N'新北市鶯歌區永和街101號')
INSERT [dbo].[Supplier] ([supplier_id], [supplier_name], [supplier_tel], [supplier_address]) VALUES (5, N'安內科技股份有限公司', N'0226980818', N'新北市汐止區新台五路1段8號4樓之3')
INSERT [dbo].[Supplier] ([supplier_id], [supplier_name], [supplier_tel], [supplier_address]) VALUES (6, N'賺飽飽國際有限公司', N'068903247', N'台南市中西區民族路66號')
SET IDENTITY_INSERT [dbo].[Supplier] OFF
GO
INSERT [dbo].[TarotCard] ([tarotCard_ID], [tarotCard_name], [tarotCard_type]) VALUES (0, N'愚者', N'0         ')
INSERT [dbo].[TarotCard] ([tarotCard_ID], [tarotCard_name], [tarotCard_type]) VALUES (1, N'魔術師', N'0         ')
INSERT [dbo].[TarotCard] ([tarotCard_ID], [tarotCard_name], [tarotCard_type]) VALUES (2, N'女祭司', N'0         ')
INSERT [dbo].[TarotCard] ([tarotCard_ID], [tarotCard_name], [tarotCard_type]) VALUES (3, N'皇后', N'0         ')
INSERT [dbo].[TarotCard] ([tarotCard_ID], [tarotCard_name], [tarotCard_type]) VALUES (4, N'皇帝', N'0         ')
INSERT [dbo].[TarotCard] ([tarotCard_ID], [tarotCard_name], [tarotCard_type]) VALUES (5, N'教皇', N'0         ')
INSERT [dbo].[TarotCard] ([tarotCard_ID], [tarotCard_name], [tarotCard_type]) VALUES (6, N'戀人', N'0         ')
INSERT [dbo].[TarotCard] ([tarotCard_ID], [tarotCard_name], [tarotCard_type]) VALUES (7, N'戰車', N'0         ')
INSERT [dbo].[TarotCard] ([tarotCard_ID], [tarotCard_name], [tarotCard_type]) VALUES (8, N'力量', N'0         ')
INSERT [dbo].[TarotCard] ([tarotCard_ID], [tarotCard_name], [tarotCard_type]) VALUES (9, N'隱者', N'0         ')
INSERT [dbo].[TarotCard] ([tarotCard_ID], [tarotCard_name], [tarotCard_type]) VALUES (10, N'命運之輪', N'0         ')
INSERT [dbo].[TarotCard] ([tarotCard_ID], [tarotCard_name], [tarotCard_type]) VALUES (11, N'正義', N'0         ')
INSERT [dbo].[TarotCard] ([tarotCard_ID], [tarotCard_name], [tarotCard_type]) VALUES (12, N'倒吊人', N'0         ')
INSERT [dbo].[TarotCard] ([tarotCard_ID], [tarotCard_name], [tarotCard_type]) VALUES (13, N'死神', N'0         ')
INSERT [dbo].[TarotCard] ([tarotCard_ID], [tarotCard_name], [tarotCard_type]) VALUES (14, N'節制', N'0         ')
INSERT [dbo].[TarotCard] ([tarotCard_ID], [tarotCard_name], [tarotCard_type]) VALUES (15, N'惡魔', N'0         ')
INSERT [dbo].[TarotCard] ([tarotCard_ID], [tarotCard_name], [tarotCard_type]) VALUES (16, N'高塔', N'0         ')
INSERT [dbo].[TarotCard] ([tarotCard_ID], [tarotCard_name], [tarotCard_type]) VALUES (17, N'星星', N'0         ')
INSERT [dbo].[TarotCard] ([tarotCard_ID], [tarotCard_name], [tarotCard_type]) VALUES (18, N'月亮', N'0         ')
INSERT [dbo].[TarotCard] ([tarotCard_ID], [tarotCard_name], [tarotCard_type]) VALUES (19, N'太陽', N'0         ')
INSERT [dbo].[TarotCard] ([tarotCard_ID], [tarotCard_name], [tarotCard_type]) VALUES (20, N'審判', N'0         ')
INSERT [dbo].[TarotCard] ([tarotCard_ID], [tarotCard_name], [tarotCard_type]) VALUES (21, N'世界', N'0         ')
INSERT [dbo].[TarotCard] ([tarotCard_ID], [tarotCard_name], [tarotCard_type]) VALUES (22, N'權杖王牌', N'1         ')
INSERT [dbo].[TarotCard] ([tarotCard_ID], [tarotCard_name], [tarotCard_type]) VALUES (23, N'權杖二', N'1         ')
INSERT [dbo].[TarotCard] ([tarotCard_ID], [tarotCard_name], [tarotCard_type]) VALUES (24, N'權杖三', N'1         ')
INSERT [dbo].[TarotCard] ([tarotCard_ID], [tarotCard_name], [tarotCard_type]) VALUES (25, N'權杖四', N'1         ')
INSERT [dbo].[TarotCard] ([tarotCard_ID], [tarotCard_name], [tarotCard_type]) VALUES (26, N'權杖五', N'1         ')
INSERT [dbo].[TarotCard] ([tarotCard_ID], [tarotCard_name], [tarotCard_type]) VALUES (27, N'權杖六', N'1         ')
INSERT [dbo].[TarotCard] ([tarotCard_ID], [tarotCard_name], [tarotCard_type]) VALUES (28, N'權杖七', N'1         ')
INSERT [dbo].[TarotCard] ([tarotCard_ID], [tarotCard_name], [tarotCard_type]) VALUES (29, N'權杖八', N'1         ')
INSERT [dbo].[TarotCard] ([tarotCard_ID], [tarotCard_name], [tarotCard_type]) VALUES (30, N'權杖九', N'1         ')
INSERT [dbo].[TarotCard] ([tarotCard_ID], [tarotCard_name], [tarotCard_type]) VALUES (31, N'權杖十', N'1         ')
INSERT [dbo].[TarotCard] ([tarotCard_ID], [tarotCard_name], [tarotCard_type]) VALUES (32, N'權杖侍者', N'1         ')
INSERT [dbo].[TarotCard] ([tarotCard_ID], [tarotCard_name], [tarotCard_type]) VALUES (33, N'權杖騎士', N'1         ')
INSERT [dbo].[TarotCard] ([tarotCard_ID], [tarotCard_name], [tarotCard_type]) VALUES (34, N'權杖皇后', N'1         ')
INSERT [dbo].[TarotCard] ([tarotCard_ID], [tarotCard_name], [tarotCard_type]) VALUES (35, N'權杖國王', N'1         ')
INSERT [dbo].[TarotCard] ([tarotCard_ID], [tarotCard_name], [tarotCard_type]) VALUES (36, N'聖杯王牌', N'1         ')
INSERT [dbo].[TarotCard] ([tarotCard_ID], [tarotCard_name], [tarotCard_type]) VALUES (37, N'聖杯二', N'1         ')
INSERT [dbo].[TarotCard] ([tarotCard_ID], [tarotCard_name], [tarotCard_type]) VALUES (38, N'聖杯三', N'1         ')
INSERT [dbo].[TarotCard] ([tarotCard_ID], [tarotCard_name], [tarotCard_type]) VALUES (39, N'聖杯四', N'1         ')
INSERT [dbo].[TarotCard] ([tarotCard_ID], [tarotCard_name], [tarotCard_type]) VALUES (40, N'聖杯五', N'1         ')
INSERT [dbo].[TarotCard] ([tarotCard_ID], [tarotCard_name], [tarotCard_type]) VALUES (41, N'聖杯六', N'1         ')
INSERT [dbo].[TarotCard] ([tarotCard_ID], [tarotCard_name], [tarotCard_type]) VALUES (42, N'聖杯七', N'1         ')
INSERT [dbo].[TarotCard] ([tarotCard_ID], [tarotCard_name], [tarotCard_type]) VALUES (43, N'聖杯八', N'1         ')
INSERT [dbo].[TarotCard] ([tarotCard_ID], [tarotCard_name], [tarotCard_type]) VALUES (44, N'聖杯九', N'1         ')
INSERT [dbo].[TarotCard] ([tarotCard_ID], [tarotCard_name], [tarotCard_type]) VALUES (45, N'聖杯十', N'1         ')
INSERT [dbo].[TarotCard] ([tarotCard_ID], [tarotCard_name], [tarotCard_type]) VALUES (46, N'聖杯侍者', N'1         ')
INSERT [dbo].[TarotCard] ([tarotCard_ID], [tarotCard_name], [tarotCard_type]) VALUES (47, N'聖杯騎士', N'1         ')
INSERT [dbo].[TarotCard] ([tarotCard_ID], [tarotCard_name], [tarotCard_type]) VALUES (48, N'聖杯皇后', N'1         ')
INSERT [dbo].[TarotCard] ([tarotCard_ID], [tarotCard_name], [tarotCard_type]) VALUES (49, N'聖杯國王', N'1         ')
INSERT [dbo].[TarotCard] ([tarotCard_ID], [tarotCard_name], [tarotCard_type]) VALUES (50, N'寶劍王牌', N'1         ')
INSERT [dbo].[TarotCard] ([tarotCard_ID], [tarotCard_name], [tarotCard_type]) VALUES (51, N'寶劍二', N'1         ')
INSERT [dbo].[TarotCard] ([tarotCard_ID], [tarotCard_name], [tarotCard_type]) VALUES (52, N'寶劍三', N'1         ')
INSERT [dbo].[TarotCard] ([tarotCard_ID], [tarotCard_name], [tarotCard_type]) VALUES (53, N'寶劍四', N'1         ')
INSERT [dbo].[TarotCard] ([tarotCard_ID], [tarotCard_name], [tarotCard_type]) VALUES (54, N'寶劍五', N'1         ')
INSERT [dbo].[TarotCard] ([tarotCard_ID], [tarotCard_name], [tarotCard_type]) VALUES (55, N'寶劍六', N'1         ')
INSERT [dbo].[TarotCard] ([tarotCard_ID], [tarotCard_name], [tarotCard_type]) VALUES (56, N'寶劍七', N'1         ')
INSERT [dbo].[TarotCard] ([tarotCard_ID], [tarotCard_name], [tarotCard_type]) VALUES (57, N'寶劍八', N'1         ')
INSERT [dbo].[TarotCard] ([tarotCard_ID], [tarotCard_name], [tarotCard_type]) VALUES (58, N'寶劍九', N'1         ')
INSERT [dbo].[TarotCard] ([tarotCard_ID], [tarotCard_name], [tarotCard_type]) VALUES (59, N'寶劍十', N'1         ')
INSERT [dbo].[TarotCard] ([tarotCard_ID], [tarotCard_name], [tarotCard_type]) VALUES (60, N'寶劍侍者', N'1         ')
INSERT [dbo].[TarotCard] ([tarotCard_ID], [tarotCard_name], [tarotCard_type]) VALUES (61, N'寶劍騎士', N'1         ')
INSERT [dbo].[TarotCard] ([tarotCard_ID], [tarotCard_name], [tarotCard_type]) VALUES (62, N'寶劍皇后', N'1         ')
INSERT [dbo].[TarotCard] ([tarotCard_ID], [tarotCard_name], [tarotCard_type]) VALUES (63, N'寶劍國王', N'1         ')
INSERT [dbo].[TarotCard] ([tarotCard_ID], [tarotCard_name], [tarotCard_type]) VALUES (64, N'錢幣王牌', N'1         ')
INSERT [dbo].[TarotCard] ([tarotCard_ID], [tarotCard_name], [tarotCard_type]) VALUES (65, N'錢幣二', N'1         ')
INSERT [dbo].[TarotCard] ([tarotCard_ID], [tarotCard_name], [tarotCard_type]) VALUES (66, N'錢幣三', N'1         ')
INSERT [dbo].[TarotCard] ([tarotCard_ID], [tarotCard_name], [tarotCard_type]) VALUES (67, N'錢幣四', N'1         ')
INSERT [dbo].[TarotCard] ([tarotCard_ID], [tarotCard_name], [tarotCard_type]) VALUES (68, N'錢幣五', N'1         ')
INSERT [dbo].[TarotCard] ([tarotCard_ID], [tarotCard_name], [tarotCard_type]) VALUES (69, N'錢幣六', N'1         ')
INSERT [dbo].[TarotCard] ([tarotCard_ID], [tarotCard_name], [tarotCard_type]) VALUES (70, N'錢幣七', N'1         ')
INSERT [dbo].[TarotCard] ([tarotCard_ID], [tarotCard_name], [tarotCard_type]) VALUES (71, N'錢幣八', N'1         ')
INSERT [dbo].[TarotCard] ([tarotCard_ID], [tarotCard_name], [tarotCard_type]) VALUES (72, N'錢幣九', N'1         ')
INSERT [dbo].[TarotCard] ([tarotCard_ID], [tarotCard_name], [tarotCard_type]) VALUES (73, N'錢幣十', N'1         ')
INSERT [dbo].[TarotCard] ([tarotCard_ID], [tarotCard_name], [tarotCard_type]) VALUES (74, N'錢幣侍者', N'1         ')
INSERT [dbo].[TarotCard] ([tarotCard_ID], [tarotCard_name], [tarotCard_type]) VALUES (75, N'錢幣騎士', N'1         ')
INSERT [dbo].[TarotCard] ([tarotCard_ID], [tarotCard_name], [tarotCard_type]) VALUES (76, N'錢幣皇后', N'1         ')
INSERT [dbo].[TarotCard] ([tarotCard_ID], [tarotCard_name], [tarotCard_type]) VALUES (77, N'錢幣國王', N'1         ')
GO

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ChilLaxBackEnd.ViewModel
{
    public class MemberViewModel
    {
        [DisplayName("編號")]
        public int member_id { get; set; }

        [DisplayName("客戶名稱")]
        [Required(ErrorMessage = "客戶名稱必須填寫")]
        public string member_name { get; set; }

        [DisplayName("聯絡電話")]
        [Required(ErrorMessage = "電話必須填寫")]
        [RegularExpression(@"^\d{4}-\d{6}$", ErrorMessage = "請輸入有效的電話號碼，格式為 0912-345678")]//改1
        public string member_tel { get; set; }

        [DisplayName("地址")]
        public string member_address { get; set; }

        [DisplayName("信箱")]
        [Required(ErrorMessage = "信箱必須填寫")]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "請輸入有效的信箱")]
        public string member_email { get; set; }

        [DisplayName("出生年月日")]
        [Required(ErrorMessage = "出生年月日必須填寫")]
        [DataType(DataType.Date)]//改2
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]//改3
        public System.DateTime member_birthday { get; set; }

        [DisplayName("性別")]
        public Nullable<bool> member_sex { get; set; }

        [DisplayName("點數")]
        public Nullable<int> member_point { get; set; }

        [DisplayName("加入時間")]
        [Required(ErrorMessage = "加入時間必須填寫")]
        [DataType(DataType.DateTime)]//改4
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]//改5
        public System.DateTime member_joinTime { get; set; }

        [DisplayName("會員帳號")]
        [Required(ErrorMessage = "會員帳號必須填寫")]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "帳號只能包含英文字母和數字")]
        public string member_account { get; set; }


    }
}
//        [Required(ErrorMessage = "品名必須填寫")]
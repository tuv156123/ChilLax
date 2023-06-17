using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChilLaxBackEnd.Models
{
    public class AnnouncementWrapper
    {
        private Announcement _anmt;
        public AnnouncementWrapper()
        {
            if (_anmt == null)
                _anmt = new Announcement();
        }
        public Announcement anmt
        {
            get { return _anmt; }
            set { _anmt = value; }
        }

        public int announcement_id 
        {   get { return _anmt.announcement_id; }
            set { _anmt.announcement_id = value; }
        }

        [DisplayName("公告內容")]
        [Required(ErrorMessage ="此欄位為必填!")]
        public string announcement
        {
            get { return _anmt.announcement; }
            set { _anmt.announcement = value; }
        }

        [DisplayName("起始日")]
        [Required(ErrorMessage = "此欄位為必填!")]
        [DataType(DataType.Date)]
        public System.DateTime start_date
        {
            get { return _anmt.start_date; }
            set { _anmt.start_date = value; }
        }

        [DisplayName("終止日")]
        [Required(ErrorMessage = "此欄位為必填!")]
        [DataType(DataType.Date)]
        public System.DateTime end_date
        {
            get { return _anmt.end_date; }
            set { _anmt.end_date = value; }
        }

        [DisplayName("專注贈點倍率")]
        [Required(ErrorMessage = "此欄位為必填!")]
        public int bonus_for_focus
        {
            get { return _anmt.bonus_for_focus; }
            set { _anmt.bonus_for_focus = value; }
        }

        [DisplayName("購物贈點倍率")]
        [Required(ErrorMessage = "此欄位為必填!")]
        public int bonus_for_shopping
        {
            get { return _anmt.bonus_for_shopping; }
            set { _anmt.bonus_for_shopping = value; }
        }
    }
}
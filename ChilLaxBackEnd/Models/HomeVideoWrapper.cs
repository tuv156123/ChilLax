using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChilLaxBackEnd.Models
{
    public class HomeVideoWrapper
    {
        private HomeVideo _hv;
        public HomeVideoWrapper()
        {
            if (_hv == null)
                _hv = new HomeVideo();
        }
        public HomeVideo hv
        {
            get { return _hv; }
            set { _hv = value; }
        }
        public int video_id
        {
            get { return _hv.video_id; }
            set { _hv.video_id = value; }
        }

        [DisplayName("主題")]
        [Required(ErrorMessage = "此欄位為必填!")]
        public string video_name
        {
            get { return _hv.video_name; }
            set { _hv.video_name = value; }
        }

        [DisplayName("影片名稱")]
        public string video_path
        {
            get { return _hv.video_path; }
            set { _hv.video_path = value; }
        }

        [DisplayName("影片檔")]
        [Required(ErrorMessage = "此欄位為必填!")]
        [FileExtensions(ErrorMessage = "請上傳.mp4格式檔案", Extensions = "mp4")]

        public HttpPostedFileBase video { get; set; }
    }
}
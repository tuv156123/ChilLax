using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChilLaxBackEnd.Models
{
    public class FocusSlideWrapper
    {
        private FocusSlide _fs;
        public FocusSlideWrapper()
        {
            if (_fs == null)
                _fs = new FocusSlide();
        }
        public FocusSlide fs
        {
            get { return _fs; }
            set { _fs = value; }
        }
        public int focus_id
        {
            get { return _fs.focus_id; }
            set { _fs.focus_id = value; }
        }
        [DisplayName("情境")]
        [Required(ErrorMessage = "此欄位為必填!")]
        public string category
        {
            get { return _fs.category; }
            set { _fs.category = value; }
        }

        [DisplayName("圖檔名稱")]
        public string image_path
        {
            get { return _fs.image_path; }
            set { _fs.image_path = value; }
        }

        [DisplayName("音檔名稱")]
        public string audio_path
        {
            get { return _fs.audio_path; }
            set { _fs.audio_path = value; }
        }

        [DisplayName("圖檔")]
        [Required(ErrorMessage = "此欄位為必填!")]
        //[FileExtensions(ErrorMessage = "請上傳.jpg/.jpeg/.png格式檔案", Extensions = "jpg,jpeg,png")]
        public HttpPostedFileBase image { get; set; }

        [DisplayName("音檔")]
        [Required(ErrorMessage = "此欄位為必填!")]
        //[FileExtensions(ErrorMessage = "請上傳.mp3/.m4a格式檔案", Extensions = "mp3,m4a")]
        public HttpPostedFileBase audio { get; set; }
    }
}
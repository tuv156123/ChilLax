using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ChilLaxBackEnd.Models
{
    public class ProductWrapper
    {
        private Product _pd;
        public ProductWrapper()
        {
            if (_pd == null)
                _pd = new Product();
        }
        public Product pd
        {
            get { return _pd; }
            set { _pd = value; }
        }
        public int product_id
        {
            get { return _pd.product_id; }
            set { _pd.product_id = value; }
        }
        public int supplier_id
        {
            get { return _pd.supplier_id; }
            set { _pd.supplier_id = value; }
        }
        public string product_name
        {
            get { return _pd.product_name; }
            set { _pd.product_name = value; }
        }
        public string product_desc
        {
            get { return _pd.product_desc; }
            set { _pd.product_desc = value; }
        }
        public int product_price
        {
            get { return _pd.product_price; }
            set { _pd.product_price = value; }
        }
        public string product_img
        {
            get { return _pd.product_img; }
            set { _pd.product_img = value; }
        }
        public int product_quantity
        {
            get { return _pd.product_quantity; }
            set { _pd.product_quantity = value; }
        }
        public string product_category
        {
            get { return _pd.product_category; }
            set { _pd.product_category = value; }
        }
        public bool product_state
        {
            get { return _pd.product_state; }
            set { _pd.product_state = value; }
        }
        public HttpPostedFileBase photo { get; set; }
    }
}
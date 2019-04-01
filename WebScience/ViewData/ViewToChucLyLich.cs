using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebScience.ViewData
{
    public class ViewToChucLyLich
    {
        public int Id { get; set; }

        public int IdLyLich { get; set; }

        public string MaLyLich { get; set; }

        public string TenToChuc { get; set; }

        public string TenNguoiLanhDao { get; set; }

        public string DienThoaiLanhDao { get; set; }

        public string DiaChiToChuc { get; set; }

        public string GhiChu { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebScience.ViewData
{
    public class ViewDaoTaoLyLich
    {
        public int Id { get; set; }

        public int IdLyLich { get; set; }

        public string MaLyLich { get; set; }

        public string MaBacDaoTao { get; set; }

        public string TenBacDaoTao { get; set; }

        public string NoiDaoTao { get; set; }

        public string ChuyenMon { get; set; }

        public string NamTotNghiep { get; set; }

        public string GhiChu { get; set; }
    }
}
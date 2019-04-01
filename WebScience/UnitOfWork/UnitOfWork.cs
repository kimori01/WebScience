using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebScience.Models;

namespace WebScience.UnitOfWork
{
    public class UnitOfWork : IDisposable
    {
        private ModelScience context = new ModelScience();
        private GenericRepository<tb_LyLich> _lylichRepository;
        private GenericRepository<tb_HocHam> _hochamRepository;
        private GenericRepository<tb_HocVi> _hocviRepository;
        private GenericRepository<tb_ToChuc> _tochucRepository;
        private GenericRepository<tb_QuaTrinhCongTac> _quatrinhcongtacRepository;
        private GenericRepository<tb_QuaTrinhDaoTao> _quatrinhdaotaoRepository;
        private GenericRepository<tb_DeTai> _detaiRepository;
        //private GenericRepository<tb_BaoChi> _baochiRepository;

        public GenericRepository<tb_DeTai> DeTaiRepository
        {
            get
            {
                if (this._detaiRepository == null)
                {
                    this._detaiRepository = new GenericRepository<tb_DeTai>(context);
                }
                return _detaiRepository;
            }
        }

        public GenericRepository<tb_ToChuc> ToChucRepository
        {
            get
            {
                if (this._tochucRepository == null)
                {
                    this._tochucRepository = new GenericRepository<tb_ToChuc>(context);
                }
                return _tochucRepository;
            }
        }

        public GenericRepository<tb_QuaTrinhCongTac> QuaTrinhCongTacRepository
        {
            get
            {
                if (this._quatrinhcongtacRepository == null)
                {
                    this._quatrinhcongtacRepository = new GenericRepository<tb_QuaTrinhCongTac>(context);
                }
                return _quatrinhcongtacRepository;
            }
        }

        public GenericRepository<tb_QuaTrinhDaoTao> QuaTrinhDaoTaoRepository
        {
            get
            {
                if (this._quatrinhdaotaoRepository == null)
                {
                    this._quatrinhdaotaoRepository = new GenericRepository<tb_QuaTrinhDaoTao>(context);
                }
                return _quatrinhdaotaoRepository;
            }
        }

        public GenericRepository<tb_LyLich> LyLichRepository
        {
            get
            {
                if (this._lylichRepository == null)
                {
                    this._lylichRepository = new GenericRepository<tb_LyLich>(context);
                }
                return _lylichRepository;
            }
        }



        public GenericRepository<tb_HocHam> HocHamRepository
        {
            get
            {

                if (this._hochamRepository == null)
                {
                    this._hochamRepository = new GenericRepository<tb_HocHam>(context);
                }
                return _hochamRepository;
            }
        }

        public GenericRepository<tb_HocVi> HocViRepository
        {
            get
            {

                if (this._hocviRepository == null)
                {
                    this._hocviRepository = new GenericRepository<tb_HocVi>(context);
                }
                return _hocviRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
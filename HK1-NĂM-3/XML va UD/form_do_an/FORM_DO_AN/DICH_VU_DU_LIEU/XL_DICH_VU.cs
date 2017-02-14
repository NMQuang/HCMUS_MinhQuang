using System;
using System.Collections.Generic;

using System.Text;

using System.IO;
using System.Xml;
using System.Web.Hosting;
using System.Data;
using System.Data.OleDb;

namespace DICH_VU_DU_LIEU
{

    public enum CONG_NGHE_LUU_TRU
    {
        ACCESS,
        XML,
        CSDL
    }

    public enum BANG
    {
        GIA_DINH,
        GIOI_TINH,
        KHOAN_CHI_GIA_DINH,
        KHOAN_CHI_THANH_VIEN,
        KHOAN_THU_GIA_DINH,
        KHOAN_THU_THANH_VIEN,
        THANH_VIEN
    }
    public enum LOAI_CSDL
    { Access, SQLServer, SQLser_MDF, MySql, Sqlite }

    public class XL_DICH_VU
    {
        #region "Biến/Đối tượng toàn cục"

        protected static DirectoryInfo Thu_muc_Project = new DirectoryInfo(HostingEnvironment.ApplicationPhysicalPath);
        protected static DirectoryInfo Thu_muc_Solution = Thu_muc_Project.Parent;

        protected static string Thu_muc_Du_lieu = Thu_muc_Solution.FullName + @"\Du_lieu";
        protected static string Thu_muc_CSDL = Thu_muc_Du_lieu + @"\CSDL";
        protected static string Thu_muc_Media = Thu_muc_Du_lieu + @"\Media";
        protected static string Thu_muc_Hinh = Thu_muc_Media + @"\Hinh";
        protected static string Thu_muc_Icons = Thu_muc_Media + @"\Icons";

        protected static string Ten_Ung_dung = "QLCT";
        protected static string Phien_ban = "v2";
        protected static string Ten_Du_lieu_Luu_tru = Ten_Ung_dung + "_" + Phien_ban;

        protected static CONG_NGHE_LUU_TRU CongNghe = CONG_NGHE_LUU_TRU.CSDL;
        protected string chuoiketNoiAccess;
        protected LOAI_CSDL Loai_CSDL = LOAI_CSDL.Access;

        protected string Duong_dan_Tap_tin_Access = "";

        #endregion
        public XL_DICH_VU()
        {
            if (CongNghe == CONG_NGHE_LUU_TRU.CSDL && Loai_CSDL == LOAI_CSDL.Access)
            {
                Duong_dan_Tap_tin_Access = Thu_muc_CSDL + @"\" + Ten_Du_lieu_Luu_tru + ".mdb";
                chuoiketNoiAccess = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + Duong_dan_Tap_tin_Access;
                //chuoiketNoiAccess = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=CNXML_SV_QLGD_2_Cach_2.mdb";
            }
        }
        #region "Xử lý CSDL Access"


        protected DataTable DocBangAccess(string tenBang, string dieuKien, DataSet duLieuADO = null)
        {
            DataTable kq = new DataTable(tenBang);
            string chuoiLenh = "select *from" + tenBang;
            if (dieuKien.Trim() != "")
                chuoiLenh += "where" + dieuKien;
            try
            {
                OleDbDataAdapter duLieuThichUng = new OleDbDataAdapter(chuoiLenh, chuoiketNoiAccess);
                duLieuThichUng.FillSchema(kq, SchemaType.Source);
                duLieuThichUng.Fill(kq);
                if (duLieuADO != null)
                    duLieuADO.Tables.Add(kq);
                kq.Columns[0].ReadOnly = false;
                foreach (DataColumn cot in kq.Columns)
                    cot.ColumnMapping = MappingType.Attribute;
            }
            catch (Exception loi)
            {
                kq.ExtendedProperties["chuoiLoi"] = loi.Message;
            }
            return kq;
        }

        private void CaiDatKhoaChinh(DataTable bang)
        {
            DataColumn[] khoa = new DataColumn[1];
            khoa[0] = bang.Columns["ID"];
            bang.PrimaryKey = khoa;
        }
        protected string GhiBangAccess(DataTable Bang)
        {
            CaiDatKhoaChinh(Bang);
            string ketQua = "";
            string tenBang = Bang.TableName;
            string lenhSelect = "select * from " + tenBang;
            string lenhDelete = "delete from" + tenBang;
            string lenhThamChieu = "alter table" + tenBang + "alter column ID autoincrement(1,1)";
            OleDbConnection con = new OleDbConnection(chuoiketNoiAccess);
            try
            {
                //Xóa dữ liệu
                OleDbCommand cmd = new OleDbCommand(lenhDelete, con);
                con.Open();
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();

                //Viết lại bảng
                cmd = new OleDbCommand(lenhThamChieu, con);
                con.Open();
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                con.Close();

                //Thêm dữ liệu
                OleDbDataAdapter duLieuThichUng = new OleDbDataAdapter(lenhSelect, chuoiketNoiAccess);
                OleDbCommandBuilder lenhPhatSinh = new OleDbCommandBuilder(duLieuThichUng);
                duLieuThichUng.RowUpdated += XL_Bien_co_moi;
                duLieuThichUng.Update(Bang);
                duLieuThichUng.Dispose();
            }
            catch (Exception loi)
            {
                ketQua = loi.Message;
            }
            return ketQua;
        }
        private void XL_Bien_co_moi(object Doi_tuong, OleDbRowUpdatedEventArgs Thong_tin_Bien_co)
        {
            // Ket_noi = Kết nối đang sử dụng 
            OleDbConnection Ket_noi = Thong_tin_Bien_co.Command.Connection;
            //  Kiểm tra là lệnh thêm mới 
            if (Thong_tin_Bien_co.StatementType == StatementType.Insert)
            {
                OleDbCommand Lenh = new OleDbCommand("Select @@IDENTITY", Ket_noi);
                // ID = Kết quả thực hiện Lenh 
                int ID = (int)Lenh.ExecuteScalar();
                // Gán ID vào cột ID  của dòng vừa thêm vào 
                Thong_tin_Bien_co.Row["ID"] = ID;
            }

        }


        #endregion

        #region "Xử lí"
        protected string GhiBangVaoCSDL(XmlElement root, string tenBang)
        {
            string ketQua = "";
            try
            {
                DataSet duLieuDAO = new DataSet();
                StringReader stringReader = new StringReader(root.ParentNode.OuterXml);

                duLieuDAO.ReadXml(stringReader);
                foreach (DataTable bang in duLieuDAO.Tables)
                {
                    if (bang.TableName == tenBang)
                    {
                        ketQua = GhiBangAccess(bang);
                        break;
                    }
                }
            }
            catch (Exception loi)
            {
                ketQua = loi.Message;
            }
            return ketQua;
        }

        protected DataTable DocBang(string tenBang, string dieuKien = "", DataSet duLieuDAO = null)
        {
            DataTable ketQua = new DataTable();
            if (CongNghe == CONG_NGHE_LUU_TRU.ACCESS)
            {
                ketQua = DocBangAccess(tenBang, dieuKien, duLieuDAO);
            }
            return ketQua;
        }
        protected XmlElement DocBangTuCSDL(string tenBang)
        {
            XmlElement ketQua = null;
            DataSet duLieuDAO = new DataSet();
            duLieuDAO.DataSetName = Ten_Du_lieu_Luu_tru;
            DocBang(tenBang, "", duLieuDAO);

            string chuoiXML = duLieuDAO.GetXml();
            XmlDocument taiLieu = new XmlDocument();
            taiLieu.LoadXml(chuoiXML);
            ketQua = taiLieu.DocumentElement;
            return ketQua;

        }

        protected string GhiDuLieuVaoCSDL(XmlElement root)
        {
            string ketQua = "";
            try
            {
                DataSet duLieuDAO = new DataSet();
                StringReader stringReader = new StringReader(root.ParentNode.OuterXml);

                duLieuDAO.ReadXml(stringReader);
                foreach (DataTable bang in duLieuDAO.Tables)
                {
                    ketQua = GhiBangAccess(bang);
                    break;

                }
            }
            catch (Exception loi)
            {
                ketQua = loi.Message;
            }
            return ketQua;
        }

        protected XmlElement DocDuLieuTuCSDL()
        {
            XmlElement ketQua = null;
            DataSet duLieuADO = new DataSet();
            duLieuADO.DataSetName = Ten_Du_lieu_Luu_tru;
            DocBang("GIA_DINH", "", duLieuADO);
            DocBang("GIOI_TINH", "", duLieuADO);
            DocBang("KHOAN_CHI_GIA_DINH", "", duLieuADO);
            DocBang("KHOAN_CHI_THANH_VIEN", "", duLieuADO);
            DocBang("KHOAN_THU_GIA_DINH", "", duLieuADO);
            DocBang("KHOAN_THU_THANH_VIEN", "", duLieuADO);
            DocBang("THANH_VIEN", "", duLieuADO);

            string Chuoi_Xml = duLieuADO.GetXml();
            XmlDocument Tai_lieu = new XmlDocument();
            Tai_lieu.LoadXml(Chuoi_Xml);

            ketQua = Tai_lieu.DocumentElement;
            return ketQua;

        }

        public string Xoa(XmlElement doiTuong)
        {
            string ketQua = "";
            try
            {
                XmlElement root = DocBangTuCSDL(doiTuong.Name);
                for (int i = 0; i < root.ChildNodes.Count; i++)
                {
                    if (doiTuong.Name == root.ChildNodes[i].Name && doiTuong.GetAttribute("ID") == root.ChildNodes[i].Attributes["ID"].Value)
                    {
                        root.RemoveChild(root.ChildNodes[i]);
                    }
                }
                GhiBangVaoCSDL(root, doiTuong.Name);
                ketQua = root.InnerXml;
            }
            catch (Exception loi)
            {
                ketQua = loi.Message;
            }
            return ketQua;
        }

        public string CapNhat(XmlElement doiTuong)
        {
            string ketQua = "";
            try
            {
                XmlElement root = DocBangTuCSDL(doiTuong.Name);
                XmlNode newElement = root.OwnerDocument.ImportNode(doiTuong, true);
                for (int i = 0; i < root.ChildNodes.Count; i++)
                {
                    if (doiTuong.Name == root.ChildNodes[i].Name && doiTuong.GetAttribute("ID") == root.ChildNodes[i].Attributes["ID"].Value)
                    {
                        root.ReplaceChild(newElement, root.ChildNodes[i]);
                    }
                }
                GhiBangVaoCSDL(root, doiTuong.Name);
                ketQua = root.InnerXml;
            }
            catch (Exception loi)
            {
                ketQua = loi.Message;
            }
            return ketQua;
        }

        public string GhiMoi(XmlElement doiTuong)
        {
            string ketQua = "";
            try
            {
                XmlElement root = DocBangTuCSDL(doiTuong.Name);
                XmlNode newElement = root.OwnerDocument.ImportNode(doiTuong, true);
                root.AppendChild(newElement);
                GhiBangVaoCSDL(root, doiTuong.Name);
                ketQua = root.InnerXml;
            }
            catch (Exception loi)
            {
                ketQua = loi.Message;
            }
            return ketQua;
        }

        public string GhiGoc(XmlElement root)
        {
            string ketQua = "";
            try
            {
                ketQua = GhiDuLieuVaoCSDL(root);
            }
            catch (Exception loi)
            {
                ketQua = loi.Message;
            }
            return ketQua;
        }

        public XmlElement DocGoc()
        {

            XmlElement ketQua = null;
            if (CongNghe == CONG_NGHE_LUU_TRU.CSDL)
                ketQua = DocDuLieuTuCSDL();
            return ketQua;

        }
        #endregion
    }
}

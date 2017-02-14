using System;
using System.Collections.Generic;
 
using System.Text;
 
using System.IO;
using System.Xml;
using System.Web.Hosting;
using System.Data;
using System.Data.OleDb;
public enum CONG_NGHE_LUU_TRU
{   CSDL,
    XML
}
public enum LOAI_CSDL
{ Access,SQLServer,SQLser_MDF, MySql,Sqlite}
public  class XL_LUU_TRU
 {
    #region "Biến/Đối tượng toàn cục"
    
    protected static DirectoryInfo thuMucProject = new DirectoryInfo(HostingEnvironment.ApplicationPhysicalPath);
    protected static DirectoryInfo thuMucSolution = thuMucProject.Parent;

    protected static string thuMucDuLieu = thuMucSolution.FullName + @"\Du_lieu";
    protected static string thuMucCSDL = thuMucDuLieu + @"\CSDL";
    protected static string thuMucMedia = thuMucDuLieu + @"\Media";
    protected static string thuMucHinh = thuMucMedia + @"\Hinh";

    protected static string tenUngDung = "QLCT";
    protected static string phienBan = "v2";
    protected static string tenDuLieuLuuTru = tenUngDung + "_" + phienBan;

    protected static CONG_NGHE_LUU_TRU congNghe = CONG_NGHE_LUU_TRU.CSDL;
    protected LOAI_CSDL loaiCSDL = LOAI_CSDL.Access;
    protected string chuoiKetNoiAccess;
    protected string duongdanTapTinAccess = "";
    #endregion

    #region "Xử lý : Khởi động"
    public XL_LUU_TRU()
    {
        if (congNghe == CONG_NGHE_LUU_TRU.CSDL && loaiCSDL == LOAI_CSDL.Access)
          {
              duongdanTapTinAccess = thuMucCSDL + @"\" + tenDuLieuLuuTru + ".mdb";
              chuoiKetNoiAccess = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + duongdanTapTinAccess;
            //  Thông báo PET: hay có thể sử dụng
            //  Chuoi_ket_noi_Access = "Provider=Microsoft.ACE.OLEDB.12.0;" & "Data Source=" & Duong_dan_Tap_tin_Access
            // === > Thực hiện tốt hơn !!!
          //  Các anh chị có thể download Driver thư viện tại địa chỉ
            // https://www.microsoft.com/en-us/download/details.aspx?id=13255
        }
    }
    #endregion

    #region "Xử lý : Đọc -Ghi dữ liệu có cấu trúc"
    public XmlElement docDuLieu()
    {
        XmlElement ketQua=null;
        if (congNghe == CONG_NGHE_LUU_TRU.CSDL)
            ketQua = docDuLieuTuCSDL();
        return ketQua;
    }

    protected XmlElement docDuLieuTuCSDL()
    {
        XmlElement ketQua = null;
        DataSet dataSet = new DataSet();
        dataSet.DataSetName = tenDuLieuLuuTru;
        docBang("GIA_DINH", "*", "", dataSet);
        docBang("GIOI_TINH", "*", "", dataSet);
        docBang("KHOAN_CHI_GIA_DINH", "*", "", dataSet);
        docBang("KHOAN_CHI_THANH_VIEN", "*", "", dataSet);
        docBang("KHOAN_THU_GIA_DINH", "*", "", dataSet);
        docBang("KHOAN_THU_THANH_VIEN", "*", "", dataSet);
        docBang("THANH_VIEN", "*", "", dataSet);

        string chuoiXml = dataSet.GetXml();
        XmlDocument taiLieu = new XmlDocument();
        taiLieu.LoadXml(chuoiXml);

        ketQua = taiLieu.DocumentElement;
        return ketQua;

    }
    public string Them(XmlElement doiTuong)
    {
        
        // Sinh viên tự thực hiện
        string ketQua = "";
        try
        {
            XmlElement root = docBangTuCSDL(doiTuong.Name);
            XmlNode newElement = root.OwnerDocument.ImportNode(doiTuong, true);
            root.AppendChild(newElement);
            ghiBangVaoCSDL(root, doiTuong.Name);
            ketQua = root.InnerXml;
        }
        catch (Exception loi)
        {
            ketQua = loi.Message;
        }
        return ketQua;
        
    }
    public string Cap_nhat(XmlElement Doi_tuong)
    {
        string Kq = "";
        // Sinh viên tự thực hiện
        string ketQua = "";
        try
        {
            XmlElement root = docBangTuCSDL(Doi_tuong.Name);
            XmlNode newElement = root.OwnerDocument.ImportNode(Doi_tuong, true);
            for (int i = 0; i < root.ChildNodes.Count; i++)
            {
                if (Doi_tuong.Name == root.ChildNodes[i].Name && Doi_tuong.GetAttribute("ID") == root.ChildNodes[i].Attributes["ID"].Value)
                {
                    root.ReplaceChild(newElement, root.ChildNodes[i]);
                }
            }
            ghiBangVaoCSDL(root, Doi_tuong.Name);
            ketQua = root.InnerXml;
        }
        catch (Exception loi)
        {
            ketQua = loi.Message;
        }
        return ketQua;
        return Kq;
    }
    public string Xoa(XmlElement Doi_tuong)
    {
        string Kq = "";
        // Sinh viên tự thực hiện
        try
        {
            XmlElement root = docBangTuCSDL(Doi_tuong.Name);
            for (int i = 0; i < root.ChildNodes.Count; i++)
            {
                if (Doi_tuong.Name == root.ChildNodes[i].Name && Doi_tuong.GetAttribute("ID") == root.ChildNodes[i].Attributes["ID"].Value)
                {
                    root.RemoveChild(root.ChildNodes[i]);
                }
            }
            ghiBangVaoCSDL(root, Doi_tuong.Name);
            Kq = root.InnerXml;
        }
        catch (Exception loi)
        {
            Kq = loi.Message;
        }
        return Kq;
    }

    public XmlElement docBangTuCSDL(string tenBang,string Cot="*",string dieuKien = "")
    {
        XmlElement ketQua = null;
        DataSet duLieuDAO = new DataSet();
        duLieuDAO.DataSetName = tenDuLieuLuuTru;
        docBang(tenBang, Cot, dieuKien, duLieuDAO);

        string chuoiXML = duLieuDAO.GetXml();
        XmlDocument taiLieu = new XmlDocument();
        taiLieu.LoadXml(chuoiXML);
        ketQua = taiLieu.DocumentElement;
        return ketQua;
    }

    private string ghiBangVaoCSDL(XmlElement root, string tenBang)
    {
        // new NotImplementedException();
        string ketQua = "";
        try
        {
            DataSet dataSet = new DataSet();
            StringReader stringReader = new StringReader(root.ParentNode.OuterXml);

            dataSet.ReadXml(stringReader);
            foreach (DataTable bang in dataSet.Tables)
            {
                if (bang.TableName == tenBang)
                {
                    ketQua = ghiBangAccess(bang);
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


    protected DataTable docBang(string tenBang, string Cot = "*", string dieuKien = "", DataSet dataSet = null)
    {
        DataTable ketQua = new DataTable();
        if (loaiCSDL == LOAI_CSDL.Access)
            ketQua = docBangAccess(tenBang,Cot, dieuKien, dataSet);
        return ketQua;
    }
    #endregion

    #region "Xử lý : Đọc -Ghi dữ liệu phi cấu trúc - Media"
    public byte[] Doc_Hinh(string Ma_so)
    {
        byte[] Kq = new byte[] { };
        string Duong_dan_Hinh = thuMucHinh + @"\" + Ma_so + ".png";
        try
        {
            Kq = File.ReadAllBytes(Duong_dan_Hinh);
        }
        catch
        {  
            Kq = new byte[] { };
        }
        return Kq;
    }

    public string Ghi_Hinh(string Ma_so, byte[] Nhi_phan_Hinh)
    {
        string Kq = "";
        // Sinh viên tự thực hiện
        return Kq;
    }

    #endregion

    #region "Xử lý CSDL Access"
    protected DataTable docBangAccess(string tenBang,string Cot="*", string dieuKien  = "",
                                  DataSet dataSet=null)
    {
        DataTable ketQua = new DataTable(tenBang);
        string chuoiLenh = "Select " + Cot +" From " + tenBang;
        if( dieuKien.Trim () !="")  
            chuoiLenh += " Where " + dieuKien;
        try
        {
            OleDbDataAdapter boThichUng = new OleDbDataAdapter(chuoiLenh, chuoiKetNoiAccess);
            boThichUng.FillSchema(ketQua, SchemaType.Source);
            boThichUng.Fill(ketQua);
            if (dataSet != null)
                dataSet.Tables.Add(ketQua);

            ketQua.Columns[0].ReadOnly = false;
            foreach (DataColumn cot in ketQua.Columns)
                cot.ColumnMapping = MappingType.Attribute;        
        }
        catch (Exception Loi)
        {
            ketQua.ExtendedProperties["Chuoi_loi"] = Loi.Message;
        }
        return ketQua;
    }
        


    public string  ghiBangAccess( DataTable Bang  )
    {

        string ketQua = "";
        string tenBang = Bang.TableName;
        string chuoiLenh = "Select  * From " + tenBang;
        try
        {
            OleDbDataAdapter boThichUng =new OleDbDataAdapter(chuoiLenh, chuoiKetNoiAccess);
            OleDbCommandBuilder Phat_sinh_lenh = new OleDbCommandBuilder(boThichUng);
            boThichUng.RowUpdated += XL_Bien_co_Nhan_ID_moi;
            boThichUng.Update(Bang);
         }
        catch ( Exception Loi)
        {
            ketQua = Loi.Message;
        }



        return ketQua;

    }

    private void XL_Bien_co_Nhan_ID_moi(object Doi_tuong, OleDbRowUpdatedEventArgs Thong_tin_Bien_co)
    {
        // Ket_noi = Kết nối đang sử dụng 
        OleDbConnection Ket_noi = Thong_tin_Bien_co.Command.Connection;
       //  Kiểm tra là lệnh thêm mới 
       if( Thong_tin_Bien_co.StatementType == StatementType.Insert  )
        {
            // Lenh = Lệnh đọc mã số phát sinh tự động 
            OleDbCommand Lenh = new OleDbCommand("Select @@IDENTITY", Ket_noi);
            // ID = Kết quả thực hiện Lenh 
            int ID = (int)Lenh.ExecuteScalar();
            // Gán ID vào cột ID  của dòng vừa thêm vào 
            Thong_tin_Bien_co.Row["ID"] = ID;
        }   
    }

   
    #endregion
}


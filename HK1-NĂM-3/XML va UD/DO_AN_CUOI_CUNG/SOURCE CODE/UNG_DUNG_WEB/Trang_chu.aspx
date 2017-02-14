<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Trang_chu.aspx.cs" Inherits="UNG_DUNG_WEB.Trang_chu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>PHẦN MỀM QUẢN LÝ CHI TIÊU CÁ NHÂN</title>
</head>
    
<body style="height: auto; width: auto;">
    <form id="form1" runat="server">
        
        <asp:Panel ID="Panel1" runat="server" style="margin-left: 30px" Width="400px" Height="200px">
            <img src="image/header.png" width="1300px" height="200px" />

        </asp:Panel>
        <marquee onmouseover = "this.stop()" onmouseout="this.start()"> <h1 style="color:blueviolet;text-shadow:initial"> MỪNG ĐẾN VỚI PHẦN MỀM QUẢN LÝ THU CHI GIA ĐÌNH</h1></marquee>
        <asp:Button ID="thongKe" Text="THỐNG KÊ" runat="server" onclick="thongKe_Click" style="background-color:azure;width:100px;height:50px;margin-top:50px;margin-left:50px"/>
        <asp:Panel ID="danhSachTheoThang" runat="server" style="margin-top:30px;" Width="600px" Height="70px">
            
        </asp:Panel>
        
        
        
        <div>
            <div id="div_rieng" style="float:left;width:600px">
                <h4>THÔNG TIN THU CHI TỪNG THÀNH VIÊN</h4>
                <asp:Panel ID="rieng" runat="server" style="margin-top:20px;height:400px">
                    <div style="border:solid 2px black;width:600px">
                        <img src="image/thanh_vien_1.png" />
                        <p ID="thanhVien1" type="text" runat="server" style="width:auto;height:auto;margin-left:10px;margin-top:5px"></p>
                     </div>
                    <div style="border:solid 2px black;width:600px">
                        <img src="image/thanh_vien_2.png" />
                        <p ID="thanhVien2" type="text" runat="server" style="width:auto;height:auto;margin-left:10px;margin-top:5px"></p>
                    </div>
                    <div style="border:solid 2px black;width:600px">
                        <img src="image/thanh_vien_3.png" />
                        <p ID="thanhVien3" type="text" runat="server" style="width:auto;height:auto;margin-left:10px;margin-top:5px"></p>
                    </div>
                    <div style="border:solid 2px black;width:600px">
                        <img src="image/thanh_vien_4.png" />
                        <p ID="thanhVien4" type="text"  runat="server" style="width:auto;height:auto;margin-left:10px;margin-top:5px"></p>
                    </div>
                  </asp:Panel>
            </div>
            <div id="div_chung" style="float:right">
                <h4 >THÔNG TIN CHUNG CỦA GIA ĐÌNH</h4>
                <div style="border:solid 2px black;height:100px">
                    <asp:Panel ID="chung" runat="server" style="margin-top:40px" Width="600px" Height="70px" >

                        <asp:Label ID="tongThu" runat="server" style="margin-left:10px;height:auto;width:auto"></asp:Label>
                        <asp:Label ID="tongChi" runat="server" style="margin-left:10px;height:auto;width:auto"></asp:Label>
                        <asp:Label ID="ketQua" runat="server" style="margin-left:10px;height:auto;width:auto"></asp:Label>
                        
                    </asp:Panel>
                </div>
                <div style="border:solid 2px black;width:600px">
                            <img src="image/2016.jpg" width="70px" height="70px" />
                            <p ID="nam1" type="text"  runat="server" style="width:auto;height:auto;margin-left:10px;margin-top:5px"></p>
                </div>
                <div style="border:solid 2px black;width:600px">
                            <img src="image/2015.jpg" width="70px" height="70px"/>
                            <p ID="nam2" type="text"  runat="server" style="width:auto;height:auto;margin-left:10px;margin-top:5px"></p>
                </div>
                <div style="border:solid 2px black;width:600px">
                            <img src="image/2014.jpg" width="70px" height="70px"/>
                            <p ID="nam3" type="text"  runat="server" style="width:auto;height:auto;margin-left:10px;margin-top:5px"></p>
                </div>
            </div>
            </div>
            

           
    </form>
</body>
</html>



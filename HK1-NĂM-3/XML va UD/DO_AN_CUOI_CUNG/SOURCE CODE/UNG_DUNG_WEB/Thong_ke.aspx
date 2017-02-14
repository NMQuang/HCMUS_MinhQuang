<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Thong_ke.aspx.cs" Inherits="UNG_DUNG_WEB.Thong_ke" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Panel ID="Panel1" runat="server" style="margin-left: 30px" Width="400px" Height="200px">
            <img src="image/header.png" width="1300px" height="200px" />

        </asp:Panel>
        <marquee onmouseover = "this.stop()" onmouseout="this.start()"> <h1 style="color:blueviolet;text-shadow:initial"> THỐNG KÊ THU CHI GIA ĐÌNH</h1></marquee>

        <div id="div_rieng" style="float:left;width:600px">
                <h4 style="background-color:aqua">THÔNG TIN THU CHI TỪNG THÀNH VIÊN</h4>
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


        <div id="thongKe" style="width:600px;float:right;height:400px">
            <h4 style="background-color:coral">THỐNG KÊ CỦA GIA ĐÌNH</h4>
            <div id="thongKeThang" style="width:600px;float:right;height:200px;background-color:aquamarine">
                <img src="image/thang.png" width="40px" style="margin-left:250px; height: 35px;" /><asp:TextBox ID="TextBox1" runat="server" Height="10px" Width="70px" style="margin-top: 0px">Tháng 12</asp:TextBox>
                <div >
                    <asp:TextBox ID="TextBox2" runat="server" style="width:60px;background-color:coral">Tổng thu</asp:TextBox>
                    <asp:Label ID="Label1" runat="server" style="margin-left:10px;height:40px;width:40px" ></asp:Label>
                     <asp:TextBox ID="TextBox3" runat="server" style="width:60px;background-color:coral">Tổng chi</asp:TextBox>
                    <asp:Label ID="Label2" runat="server" style="margin-left:10px;height:40px;width:40px" ></asp:Label>
                     <asp:TextBox ID="TextBox4" runat="server" style="width:60px;background-color:coral">Chênh lệch</asp:TextBox>
                    <asp:Label ID="Label3" runat="server" style="margin-left:10px;height:40px;width:40px" ></asp:Label>
                </div>
                <asp:GridView ID="GridView1" runat="server">
                    <Columns>
                        <asp:BoundField DataField="tenThanhVien" HeaderText="Tên Thành Viên" />
                        <asp:BoundField DataField="thu" HeaderText="Thu" />
                        <asp:BoundField DataField="chi" HeaderText="Chi" />
                        <asp:BoundField DataField="chenhLech" HeaderText="Chênh Lệch" />
                    </Columns>
                </asp:GridView>
            </div>
            
        </div>
    </div>
    </form>
</body>
</html>

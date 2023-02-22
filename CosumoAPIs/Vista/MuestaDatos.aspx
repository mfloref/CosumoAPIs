<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="MuestaDatos.aspx.vb" Inherits="CosumoAPIs.MuestaDatos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid p-2">
        <div class="container-fluid mb-2 border p-2">
            <p class="fw-bold fst-italic text-start">Consumo de API</p>
            <div class="container-fluid border p-2" style="background-color: lightcyan">
                <asp:Button ID="Button1" runat="server" Text="GET" class="btn btn-primary btn-sm" OnClick="btnConsultar_Click" />
                <span>Genera petición y agrega información solicitada a la base de datos.</span>
            </div>
        </div>
        <div class="container-fluid mb-2 border p-2">
            <p class="fw-bold fst-italic text-start">Visualización de base de datos</p>
            <div class="container-fluid border p-2 " style="background-color: lightgray">
                <asp:Button ID="btnMuestaDatos" runat="server" Text="Consulta" class="btn btn-info btn-sm" OnClick="btnMuestaDatos_Click" />
                <span>Obtiene los ultimos 4 registros para mostrarlos</span>
            </div>
        </div>
    </div>
    
    <div class="container-fluid" id="vDatos" runat="server">
        <div class="row " id="divMuestra">
            <div class="col-sm-3 text-center">
                <div class="card">
                    <div class="card-body" style="background-color: lightgreen">
                        <p>
                            <asp:Label runat="server" ID="lblTitulo1" Class="fs-2 fw-bold fst-italic"> Este es el Titulo numero 1 </asp:Label></p>
                        <p>
                            <asp:Label runat="server" ID="lblFecha1" Class="fs-5"></asp:Label></p>
                        <asp:Label runat="server" ID="lblFULLNAME1" Class="fs-6"></asp:Label>
                        <asp:Label runat="server" ID="lblPRICE1" Class="fs-6"></asp:Label>
                        <asp:Label runat="server" ID="lblHIGHDAY1" Class="fs-6"></asp:Label>
                        <asp:Label runat="server" ID="lblLOWDAY1" Class="fs-6"></asp:Label>
                        <asp:Label runat="server" ID="lblCHANGEPCT24HOUR1" Class="fs-6"></asp:Label>
                        <%--<a href="#" class="btn btn-primary">Go somewhere</a>--%>
                    </div>
                </div>
            </div>
            <div class="col-sm-3 text-center">
                <div class="card">
                    <div class="card-body" style="background-color: lightpink">
                        <p>
                            <asp:Label runat="server" ID="lblTitulo2" Class="fs-2 fw-bold fst-italic"> Este es el Titulo numero 2</asp:Label></p>
                        <p>
                            <asp:Label runat="server" ID="lblFecha2" Class="fs-5"></asp:Label></p>
                        <asp:Label runat="server" ID="lblFULLNAME2" Class="fs-6"></asp:Label>
                        <asp:Label runat="server" ID="lblPRICE2" Class="fs-6"></asp:Label>
                        <asp:Label runat="server" ID="lblHIGHDAY2" Class="fs-6"></asp:Label>
                        <asp:Label runat="server" ID="lblLOWDAY2" Class="fs-6"></asp:Label>
                        <asp:Label runat="server" ID="lblCHANGEPCT24HOUR2" Class="fs-6"></asp:Label>
                        <%--<p class="card-text">With supporting text below as a natural lead-in to additional content.</p>--%>
                        <%--<a href="#" class="btn btn-primary">Go somewhere</a>--%>
                    </div>
                </div>
            </div>
            <div class="col-sm-3 text-center">
                <div class="card">
                    <div class="card-body" style="background-color: lightsteelblue">
                        <p>
                            <asp:Label runat="server" ID="lblTitulo3" Class="fs-2 fw-bold fst-italic"> Este es el Titulo numero 3</asp:Label></p>
                        <p>
                            <asp:Label runat="server" ID="lblFecha3" Class="fs-5"></asp:Label></p>
                        <asp:Label runat="server" ID="lblFULLNAME3" Class="fs-6"> </asp:Label>
                        <asp:Label runat="server" ID="lblPRICE3" Class="fs-6"> </asp:Label>
                        <asp:Label runat="server" ID="lblHIGHDAY3" Class="fs-6"> </asp:Label>
                        <asp:Label runat="server" ID="lblLOWDAY3" Class="fs-6"></asp:Label>
                        <asp:Label runat="server" ID="lblCHANGEPCT24HOUR3" Class="fs-6"></asp:Label>
                        <%--<a href="#" class="btn btn-primary">Go somewhere</a>--%>
                    </div>
                </div>
            </div>
            <div class="col-sm-3 text-center">
                <div class="card">
                    <div class="card-body" style="background-color: lightslategray">
                        <p>
                            <asp:Label runat="server" ID="lblTitulo4" Class="fs-2 fw-bold fst-italic"> Este es el Titulo numero 4</asp:Label></p>
                        <p>
                            <asp:Label runat="server" ID="lblFecha4" Class="fs-5"></asp:Label></p>
                        <asp:Label runat="server" ID="lblFULLNAME4" Class="fs-6"></asp:Label>
                        <asp:Label runat="server" ID="lblPRICE4" Class="fs-6"></asp:Label>
                        <asp:Label runat="server" ID="lblHIGHDAY4" Class="fs-6"></asp:Label>
                        <asp:Label runat="server" ID="lblLOWDAY4" Class="fs-6"></asp:Label>
                        <asp:Label runat="server" ID="lblCHANGEPCT24HOUR4" Class="fs-6"></asp:Label>
                        <%--<a href="#" class="btn btn-primary">Go somewhere</a>--%>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

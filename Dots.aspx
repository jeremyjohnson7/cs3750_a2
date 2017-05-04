<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Dots.aspx.cs" Inherits="Dots" %>
<%
    if (Request.QueryString["clear"] != null) {
        ClearDots();
    } else if (Request.QueryString["x"] != null && Request.QueryString["y"] != null) {
        //Response.Write(Request.QueryString["x"] + ", " + Request.QueryString["y"]);
        
        int x = Int32.Parse(Request.QueryString["x"]);
        int y = Int32.Parse(Request.QueryString["y"]);

        Response.Write(AddDot(x, y));
        Response.Write("\n" + x + ", " + y + "\n");
        //AddDot(x, y);
    } else {
        Response.Write(GetDots());
    }
%>

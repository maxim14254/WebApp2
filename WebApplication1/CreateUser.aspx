<%@ Page MasterPageFile="Master.master" Language="C#" AutoEventWireup="true" CodeBehind="~/CreateUser.aspx.cs"  Inherits="WebApplication1.CreateUser"%>


<asp:Content ContentPlaceHolderId="CPH1" runat="server">
          <script src="https://unpkg.com/vue"></script>
  <form @submit="checkForm" novalidate="true" id="CreateUser" action="/SuccessCreate" method="get">
          <div style="width:35%; margin:0 40%;">
              <h2 style="margin-top:20%;">Добавление пользователя</h2>
              
              <p v-if="errors.length">
                <b>Пожалуйста исправьте указанные ошибки:</b>
                <li v-for="error in errors">{{ error }}</li>
             </p>

              <input type="text" v-model="email" id="email" name="email" style="margin:10px 5%; width: 269px;" placeholder="E-mail"><br/>
              <input type="text" v-model="name" id="name" name="name" style="margin:10px 5%; width: 269px;" placeholder="Имя"><br/>
              <input type="text" v-model="familia" id="familia" name="familia" style="margin:10px 5%; width: 269px;" placeholder="Фамилия"><br/>
              <input type="text" v-model="telephone" id="telephone" name="telephone" style="margin:10px 5%; width: 269px;" placeholder="Телефон, формат 8(999)9999999"><br/>
              <button runat="server" id="Button1" type="submit">Добавить</button>
          </div>
          <script src="Scripts/JavaScript.js"></script>
  </form>
  </asp:Content>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="recommendation.aspx.cs" Inherits="RestaurantsRecommendation.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css" integrity="sha384-9aIt2nRpC12Uk9gS9baDl411NQApFmC26EwAOH8WgZl5MYYxFfc+NcPb1dKGj7Sk" crossorigin="anonymous"/>
    <link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.13.0/css/all.css" integrity="sha384-Bfad6CLCknfcloXFOyFnlgtENryhrpZCe29RTifKEixXQZ38WheV+i/6YWSzkz3V" crossorigin="anonymous"/>

</head>
<body>
    <div class="jumbotron">
  <h1 class="display-4 text-center">Recomendacion de Restaurante</h1>
  <hr/>
  <div class="row">
      <div class="col-md-5">
          <h6 class="text-center">
              Agregar Rating
          </h6>
          
          <!-- Recommendation form -->

          <form id="form1" runat="server">
           <div style="display: grid; grid-template-columns: 50% 50%">
           <div> 

            <div class="form-group">
                <div class="input-group">
                    <div class="input-group-prepend">
                        <div class="input-group-text bg-white">
                            <i class="fas fa-user-circle"></i>
                        </div>
                    </div>
                    <!-- <select name="Iduser" class="form-control" formControlName="Iduser" placeholder="User">
                        <option *ngFor="let user of users" [value]="categoria.id">{{ categoria.descripcion }}</option>
                    </select> -->
                    <input type="text" runat="server" class="form-control" id="Iduser" placeholder="User"/>
                </div>
            </div>
            <div class="form-group">
                <div class="input-group">
                    <div class="input-group-prepend">
                        <div class="input-group-text bg-white">
                            <i class="fas fa-credit-card"></i>
                        </div>
                    </div>
                    <input type="number" runat="server" class="form-control" id="Rating" placeholder="Calificacion"/>
                </div>
            </div>
            <div class="form-group">
                <div class="input-group">
                    <div class="input-group-prepend">
                        <div class="input-group-text bg-white">
                            <i class="fas fa-calendar-alt"></i>
                        </div>
                    </div>
                    <%--<select name="RestauranID" id="RestauranID" class="form-control">
                        <option value="">Seleccione un restaurante</option>
                        <option *ngFor="let restaurant of restaurantsList" [value]="restaurant.ID">{{ restaurant?.Name }}</option>
                    </select>--%>
                    <input type="text" runat="server" class="form-control" id="RestauranID" placeholder="ID Restaurante"/>
                </div>
            </div>
            <div class="form-group">
                <div class="input-group">
                    <div class="input-group-prepend">
                        <div class="input-group-text bg-white">
                            <i class="fas fa-key"></i>
                        </div>
                    </div>
                    <input type="date" id="date" runat="server" class="form-control" placeholder="dd/mm/yyyy"/>
                </div>
            </div>


            <asp:LinkButton ID="submitBtn" class="btn btn-success btn-lg btn-block" runat="server" type="submit" OnClick="Unnamed1_Click"><i class="fas fa-database"></i> Aceptar
            </asp:LinkButton>
              </div>
              <div>
          <h6 class="text-center">
              Listado de Sugerencias
          </h6>

             <asp:ListBox ID="ListBox1" runat="server" Height="307px" Width="207px"/>
           </div>
           <div>
               </form>

          <!-- End Recommendation Form -->
  </div>
</div>
</body>
</html>

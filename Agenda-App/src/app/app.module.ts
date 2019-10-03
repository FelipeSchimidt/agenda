import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";
import { HttpClientModule } from "@angular/common/http";
import { FormsModule } from "@angular/forms";

import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";
import { UsuariosComponent } from "./usuarios/usuarios.component";
import { NavbarComponent } from "./navbar/navbar.component";
import { FootsComponent } from './foots/foots.component';

@NgModule({
   declarations: [
      AppComponent,
      UsuariosComponent,
      NavbarComponent,
      FootsComponent
   ],
   imports: [
      BrowserModule,
      AppRoutingModule,
      HttpClientModule,
      FormsModule
   ],
   providers: [],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule {}

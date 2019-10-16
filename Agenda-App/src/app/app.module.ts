import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BsDropdownModule, TooltipModule, ModalModule } from 'ngx-bootstrap';
import { AppRoutingModule } from './app-routing.module';

import { UsuarioService } from './_services/usuario.service';

import { DateTimeFormatPipe } from './_helps/DateTimeFormat.pipe';

import { AppComponent } from './app.component';
import { UsuariosComponent } from './usuarios/usuarios.component';
import { NavbarComponent } from './navbar/navbar.component';
import { FootsComponent } from './foots/foots.component';


@NgModule({
   declarations: [
	   AppComponent,
	   UsuariosComponent,
	   NavbarComponent,
	   FootsComponent,
	   DateTimeFormatPipe
	],
   	imports: [
		BrowserModule,
		AppRoutingModule,
		HttpClientModule,
		FormsModule,
		BsDropdownModule.forRoot(),
		TooltipModule.forRoot(),
		ModalModule.forRoot(),
		ReactiveFormsModule
	],
	providers: [
		UsuarioService
	],
	bootstrap: [
	   AppComponent
	]
})
export class AppModule {}

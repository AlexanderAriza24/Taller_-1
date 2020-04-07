import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HospitalizacionConsultaComponent } from './Copago/hospitalizacion-consulta/hospitalizacion-consulta.component';
import { HospitalizacionRegistroComponent } from './Copago/hospitalizacion-registro/hospitalizacion-registro.component';
import { Routes, RouterModule } from '@angular/router';

const routes: Routes = [
    {
    path: 'hospitalizacionConsulta',
    component: HospitalizacionConsultaComponent
    },
    {
      path: 'hospitalizacionRegistro',
      component: HospitalizacionRegistroComponent
    }
  ];
  

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ]
})
export class AppRoutingModule { }

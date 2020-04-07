import { Component, OnInit } from '@angular/core';
import { Hospitalizacion } from '../models/hospitalizacion';
import { HospitalizacionService } from 'src/app/services/hospitalizacion.service';

@Component({
  selector: 'app-hospitalizacion-registro',
  templateUrl: './hospitalizacion-registro.component.html',
  styleUrls: ['./hospitalizacion-registro.component.css']
})
export class HospitalizacionRegistroComponent implements OnInit {

  hospitalizacion: Hospitalizacion;
  constructor(private hospitalizacionService: HospitalizacionService) { }

  ngOnInit() {
    this.hospitalizacion= new  Hospitalizacion();
  }

  add() {
    this.hospitalizacionService.post(this.hospitalizacion).subscribe(p => {
      if (p != null) {
        alert('Hospitalizacion Registrada!');
        this.hospitalizacion = p;
      }
    });
  }
}

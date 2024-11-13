import { Component, OnInit } from '@angular/core';
import { IonicModule } from '@ionic/angular';
import { FormsModule } from '@angular/forms';
import { BaseApi } from 'src/services/apis/api-base.service';
import { Observable } from 'rxjs';
import { CommonModule } from '@angular/common';
import { IMoeda } from 'src/services/moedas/interfaces/IMoeda.interface';

@Component({
  selector: 'app-home',
  templateUrl: 'home.page.html',
  styleUrls: ['home.page.scss'],
  standalone: true,
  imports: [IonicModule, FormsModule, CommonModule],
})
export class HomePage implements OnInit {
  public cotacao!: IMoeda;

  constructor(private baseApi: BaseApi) {}

  ngOnInit(): void {
    this.baseApi.getCotacaoAtual('usd').subscribe((data: IMoeda) => {
      this.cotacao = data;
    });
  }
}

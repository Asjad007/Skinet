import { HttpClient } from '@angular/common/http';
import { Component, inject, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HeaderComponent } from './layout/header/header.component';
import { Pagination } from './shared/models/pagination';
import { Product } from './shared/models/product';
import { ShopService } from './core/Services/shop.service';
import { ShopComponent } from "./features/shop/shop.component";


@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, HeaderComponent, ShopComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent  {

  title = 'Skinet';

  }

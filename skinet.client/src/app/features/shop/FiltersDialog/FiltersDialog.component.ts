import { Component, inject, Inject, OnInit } from '@angular/core';
import { ShopService } from '../../../core/Services/shop.service';
import {MatDivider} from'@angular/material/divider';
import {MatListOption, MatSelectionList} from'@angular/material/list';
import { MAT_DIALOG_DATA, MatDialog, MatDialogRef } from '@angular/material/dialog';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-FiltersDialog',
  standalone: true,
  imports: [MatDivider,
    MatSelectionList,
    MatListOption, 
    FormsModule
  ],
  templateUrl: './FiltersDialog.component.html',
  styleUrls: ['./FiltersDialog.component.css']
})
export class FiltersDialogComponent implements OnInit {

  shopService = inject(ShopService)
  private dialogRef = inject(MatDialogRef<FiltersDialogComponent>)
  data = inject(MAT_DIALOG_DATA)

  selectedBrands: string[] = this.data.selectedBrands;
  selectedTypes: string[] = this.data.selectedTypes;


  constructor() { }

  ngOnInit() {

  }

  applyFilters(){
    this.dialogRef.close({
      selectedBrands: this.selectedBrands,
      selectedTypes: this.selectedTypes
    })
  }

}

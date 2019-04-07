import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatButtonModule, MatCheckboxModule, MatSnackBarModule, MatDialogModule } from '@angular/material';

@NgModule({
  declarations: [
  ],
  imports: [BrowserAnimationsModule, MatButtonModule, MatCheckboxModule, MatSnackBarModule, MatDialogModule],
  exports: [BrowserAnimationsModule, MatButtonModule, MatCheckboxModule, MatSnackBarModule, MatDialogModule],
  providers: [],
  bootstrap: []
})
export class MaterialModule { }

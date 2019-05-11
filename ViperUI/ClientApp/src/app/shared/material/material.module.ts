import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatButtonModule, MatCheckboxModule, MatSnackBarModule, MatDialogModule, 
         MatSelectModule, MatRadioModule, MatMenuModule, MatSidenavModule,
         MatToolbarModule, MatButtonToggleModule, MatIconModule, MatTooltipModule } from '@angular/material';

@NgModule({
  declarations: [],
  imports: [BrowserAnimationsModule, MatButtonModule, MatCheckboxModule, MatSnackBarModule, 
            MatDialogModule, MatSelectModule, MatRadioModule, MatMenuModule, MatSidenavModule,
            MatToolbarModule, MatButtonToggleModule, MatIconModule, MatTooltipModule],
  exports: [BrowserAnimationsModule, MatButtonModule, MatCheckboxModule, MatSnackBarModule, 
            MatDialogModule, MatSelectModule, MatRadioModule, MatMenuModule, MatSidenavModule,
            MatToolbarModule, MatButtonToggleModule, MatIconModule, MatTooltipModule],
  providers: [],
  bootstrap: []
})
export class MaterialModule { }

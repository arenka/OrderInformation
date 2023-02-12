import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { MatDialogModule } from '@angular/material/dialog'
import { Store } from './services/store.service';
import AppComponent from './app.component';
import { ModalComponent } from './modal/modal.component';

@NgModule({
  declarations: [
        AppComponent,
        ModalComponent
  ],
  imports: [
      BrowserModule,
      HttpClientModule,
      MatDialogModule
  ],
  providers: [Store],
    bootstrap: [AppComponent],
    entryComponents: [ModalComponent]
})
export class AppModule { }

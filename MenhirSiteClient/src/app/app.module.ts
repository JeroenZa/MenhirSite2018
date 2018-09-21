import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { ApiModule } from './api/api.module';
import { HttpClientModule } from '@angular/common/http';
import { API_BASE_URL } from './api/api.services';
import { MenuComponent } from './menu/menu.component';
import { HomeModule } from './home/home.module';
import { ArticlesModule } from './articles/articles.module';

export function apiBaseUrl() {
  return 'http://localhost/MenhirSite';
}

@NgModule({
  declarations: [
    AppComponent,
    MenuComponent,
  ],
  imports: [
    BrowserModule,
    ArticlesModule,
    HttpClientModule,
    HomeModule,
    ApiModule.forRoot(),
  ],
  providers: [
    {
      provide: API_BASE_URL,
      useFactory: apiBaseUrl
    }],
  bootstrap: [AppComponent]
})
export class AppModule { }

import { NgModule, Optional, SkipSelf, ModuleWithProviders } from '@angular/core';
import { ArticleClient, LoggingClient, TeamClient } from './api.services';
import { HttpClient } from '@angular/common/http';

@NgModule({
  declarations: []
})
export class ApiModule {
  static forRoot(): ModuleWithProviders {
    return {
      ngModule: ApiModule,
      providers: [
        ArticleClient,
        LoggingClient,
        TeamClient,
        HttpClient
      ]
    };
  }

  constructor( @Optional() @SkipSelf() parentModule: ApiModule) {
    if (parentModule) {
        throw new Error('ApiModule is already loaded. Import it in the AppModule only');
    }
  }
}

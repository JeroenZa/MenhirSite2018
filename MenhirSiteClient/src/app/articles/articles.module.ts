import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ArticleListComponent } from './article-list/article-list.component';
import { ArticleDetailsComponent } from './article-details/article-details.component';

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [
    ArticleListComponent, 
    ArticleDetailsComponent
  ]
})
export class ArticlesModule { }

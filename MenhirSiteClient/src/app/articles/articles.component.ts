import { Component, OnInit } from '@angular/core';
import { ArticleClient, Article, LoggingClient, Logging, LogLevel } from '../api/api.services';

import { timer } from 'rxjs';

@Component({
  selector: 'app-articles',
  templateUrl: './articles.component.html',
  styleUrls: ['./articles.component.css']
})
export class ArticlesComponent implements OnInit {
  articles: Article[];

  constructor(private articleClient: ArticleClient,
              private loggingClient: LoggingClient) {
   }

  ngOnInit() {
    timer(0, 30000).subscribe(t => {
      this.loadArticles();
    });
  }

  public refreshArticles() {
    this.loadArticles();
  }

  private loadArticles() {
    console.log('loaded');
    this.articleClient.getAllArticles().subscribe(response => {
      this.articles = response;
    });
  }
}

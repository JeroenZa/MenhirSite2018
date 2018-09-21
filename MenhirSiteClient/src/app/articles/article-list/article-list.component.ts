import { Component, OnInit } from '@angular/core';
import { ArticleClient, Article, LoggingClient } from '../../api/api.services';
import { timer } from 'rxjs/internal/observable/timer';

@Component({
  selector: 'app-article-list',
  templateUrl: './article-list.component.html',
  styleUrls: ['./article-list.component.css']
})
export class ArticleListComponent implements OnInit {
  articles: Article[];

  constructor(private articleClient: ArticleClient,
              private loggingClient: LoggingClient) {
   }

  ngOnInit() {
    timer(0, 60000).subscribe(t => {
      this.loadArticles();
    });
  }

  public refreshArticles() {
    this.loadArticles();
  }

  private loadArticles() {
    console.log('loaded');
    this.articleClient.getAll().subscribe(response => {
      this.articles = response.map(a => Object.assign(new Article(), a));
    });
  }
}

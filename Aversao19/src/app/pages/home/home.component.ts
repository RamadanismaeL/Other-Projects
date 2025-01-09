import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { GithubService } from '../../_services/github.service';
/**
 ** @author Ramadan Ismael
 */
@Component({
  selector: 'app-home',
  imports: [CommonModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent implements OnInit
{
  constructor(private githubService : GithubService)
  {}

  ngOnInit(): void
  {
    this.githubService.getUsers().subscribe({
      next: (response) => {
        console.log(response);
      }
    })
  }
}

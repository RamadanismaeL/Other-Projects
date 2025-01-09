import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { NavBarComponent } from "./_components/nav-bar/nav-bar.component";
import { BaseUiComponent } from "./_components/base-ui/base-ui.component";
import { FooterComponent } from "./_components/footer/footer.component";

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, NavBarComponent, BaseUiComponent, FooterComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  title = 'camara';
}

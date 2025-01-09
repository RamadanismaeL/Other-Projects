import { Routes } from '@angular/router';
import { TirarFotoComponent } from './_pages/tirar-foto/tirar-foto.component';
import { HomeComponent } from './_pages/home/home.component';
import { FazerVideoComponent } from './_pages/fazer-video/fazer-video.component';

export const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'cameras/tirarFoto', component: TirarFotoComponent},
  {path: 'cameras/fazerVideo', component: FazerVideoComponent}
];

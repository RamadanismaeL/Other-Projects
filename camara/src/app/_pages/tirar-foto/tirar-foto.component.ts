import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';

@Component({
  selector: 'app-tirar-foto',
  imports: [],
  templateUrl: './tirar-foto.component.html',
  styleUrl: './tirar-foto.component.scss'
})
export class TirarFotoComponent implements OnInit
{
  ngOnInit(): void {
    this.iniciarCamara();
  }
  @ViewChild('video', { static: true }) videoElement!: ElementRef<HTMLVideoElement>;
  @ViewChild('canvas', { static: true }) canvasElement!: ElementRef<HTMLCanvasElement>;

  iniciarCamara()
  {
    navigator.mediaDevices.getUserMedia({ video: true })
    .then(stream => {
      const video = this.videoElement.nativeElement;
      video.srcObject = stream;
      video.play();
    })
    .catch(error => console.error('Erro ao acessar a câmera', error));
  }

  tirarFoto()
  {
    const video = this.videoElement.nativeElement;
    const canvas = this.canvasElement.nativeElement;

    canvas.width = video.videoWidth;
    canvas.height = video.videoHeight;

    const context = canvas.getContext('2d');
    if(context)
    {
      context.drawImage(video, 0, 0, canvas.width, canvas.height);
      const urlCanvas = canvas.toDataURL('image/png');
      const link = document.createElement('a');
      link.href = urlCanvas;
      link.download = 'foto.png'
      link.click();
    }
  }
}

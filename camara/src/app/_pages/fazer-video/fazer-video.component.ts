import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';

@Component({
  selector: 'app-fazer-video',
  imports: [],
  templateUrl: './fazer-video.component.html',
  styleUrl: './fazer-video.component.scss'
})
export class FazerVideoComponent implements OnInit
{
  ngOnInit(): void {
    this.iniciarCamara();
  }
  @ViewChild('video', { static: true }) videoElement!: ElementRef<HTMLVideoElement>;

  mediaRecorder!: MediaRecorder;
  // blobs lida com arquivos binários grande || o que nao tem haver com web
  videoBlobs: Blob[] = [];
  gravando: boolean = false;

  iniciarCamara()
  {
    navigator.mediaDevices.getUserMedia({ video: true })
    .then(stream => {
      const video = this.videoElement.nativeElement;
      video.srcObject = stream;
      video.play();

      this.mediaRecorder = new MediaRecorder(stream);
      this.mediaRecorder.ondataavailable = (event) => {
        if(event.data.size > 0)
        {
          this.videoBlobs.push(event.data);
        }
      }
      this.mediaRecorder.onstop = this.salvarVideo.bind(this);
    })
    .catch(error => console.error('Erro ao acessar a câmera', error));
  }

  salvarVideo()
  {
    const blob = new Blob(this.videoBlobs, { type: 'video/mp4' });
    const url = window.URL.createObjectURL(blob);
    const link = document.createElement('a');
    link.href = url;
    link.download = 'gravacao.mp4';
    link.click();

    window.URL.revokeObjectURL(url);
  }

  iniciarGravacao()
  {
    if(this.mediaRecorder && this.mediaRecorder.state == 'inactive')
    {
      this.videoBlobs = [];
      this.mediaRecorder.start();
      this.gravando = true;
    }
  }

  pararGravacao()
  {
    if(this.mediaRecorder && this.mediaRecorder.state == 'recording')
    {
      this.mediaRecorder.stop();
      this.gravando = false;
    }
  }
}
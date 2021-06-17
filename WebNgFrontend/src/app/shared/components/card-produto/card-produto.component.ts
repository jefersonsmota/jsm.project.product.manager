import { Component, ElementRef, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-card-produto',
  templateUrl: './card-produto.component.html',
  styleUrls: ['./card-produto.component.css']
})
export class CardProdutoComponent implements OnInit {

  @Input() id: string = '';
  @Input() nome: string = '';
  @Input() valor: string = '';
  @Input() imagemURL: string  = '';
  @Output() editar = new EventEmitter();
  @Output() remover = new EventEmitter();

  constructor(element: ElementRef) { }

  ngOnInit(): void {
  }

  onRemover(id: string) {
    this.remover.emit(id);
  }

  onEditar(id: string) {
    this.editar.emit(id);
  }
}

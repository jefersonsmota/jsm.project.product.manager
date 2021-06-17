import { Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Product } from '../../models/product/product';

@Component({
  selector: 'app-modal',
  templateUrl: './modal.component.html',
  styleUrls: ['./modal.component.css']
})
export class ModalComponent implements OnInit, OnChanges {

  @Input() ativo: boolean = false;
  @Output() sucessoAction = new EventEmitter();
  @Output() cancelarAction = new EventEmitter();

  valor: string = '';

  @Input() productForm: FormGroup = new FormGroup({
    id: new FormControl('id'),
    nome: new FormControl('nome', [Validators.required, Validators.minLength(2)]),
    valor: new FormControl('valor', [Validators.required]),
    imagemURL: new FormControl('imagemURL', [Validators.required, Validators.minLength(10)])
  });


  constructor(fb: FormBuilder) {
  }

  ngOnChanges(changes: SimpleChanges): void {
    this.productForm = this.productForm;
  }

  ngOnInit(): void {
  }

  onSucesso() {
    this.sucessoAction.emit();
  }

  onCancelar() {
    this.cancelarAction.emit();
  }

  createForm() {

  }

}

import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Product } from 'src/app/shared/models/product/product';
import { ProductService } from 'src/app/shared/services/product/product.service';
declare const notify: any;

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  _products: Array<Product> = new Array<Product>();
  isModalActive: boolean = false;
  productForm: FormGroup;

  constructor(private _productService: ProductService, private router: Router) { 
    this.productForm = this.createForm(new Product());
  }

  async ngOnInit(): Promise<void> {
   this.loadList();
  }

  loadList() {
    this._productService.getAll({}).subscribe(res => {
      this._products = res;
    });
  }

  removeProduct(id: string) {
    this._productService.delete({Id: id}).subscribe(res => {
      notify.success('Item deleted');
      this.removeList(id);
    }, err => {
      notify.error(err.error.message);
    });
  }

  private removeList(id: string) {
    let index = this._products.findIndex(x => x.id == id);
    this._products.splice(index, 1);
  }

  editProduct(id: string) {
    let product = this._products.find(x => {
      return x.id == id;
    });

    if(product) {
      this.productForm = this.createForm(product);
      this.toggleModal();
    }
  }

  salvar() {
    if(!this.productForm.enabled) return;

    let product: Product = this.productForm.getRawValue();

    this.productForm.disable();

    if(product.id) {
      this._productService.update(product).subscribe(resp => this.successSave(resp), err => this.errorSave(err));
    } else {
      this._productService.add(product).subscribe(resp => this.successSave(resp), err => this.errorSave(err));
    }
  }

  successSave(resp: any) {
    notify.success('Item has been saved');
    setTimeout(() => {
      this.toggleModal();
      this.loadList();
      this.productForm.enable();
    }, 2000);    
  }

  errorSave(err: any) {
    notify.error(err.error.message);
  }

  adicionarForm() {
    this.productForm.reset();
    let product = new Product();
    this.productForm = this.createForm(product);
    this.toggleModal();
  }

  logout() {
    localStorage.clear();
    this.router.navigate(['/']).then(x => x);
  }

  toggleModal() {
    this.isModalActive = !this.isModalActive;
  } 

  createForm(product: Product): FormGroup {
    return new FormGroup({
      id: new FormControl(product.id),
      nome: new FormControl(product.nome, [Validators.required, Validators.minLength(5)]),
      valor: new FormControl(product.valor, [Validators.required]),
      imagemURL: new FormControl(product.imagemURL, [Validators.required, Validators.minLength(10)])
    });
  }
}

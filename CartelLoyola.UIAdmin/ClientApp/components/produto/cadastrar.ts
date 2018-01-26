import Vue from 'vue';
import { Component } from 'vue-property-decorator';

interface FormData {
    getAll(): string[]
}

interface FileReaderEventTarget extends EventTarget {
    result: string
}

interface FileReaderEvent extends Event {
    target: FileReaderEventTarget;
    getMessage(): string;
}

@Component
export default class CadastrarProdutoComponent extends Vue {

    nome: string = '';
    descricao: string = '';
    files: string = '';
    imagem: string = '';

    Upload(event: any): void {

        this.files = event.target.files[0];
        var input = event.target;

        if (input.files && input.files[0]) {

            var reader = new FileReader();

            reader.onload = (e: FileReaderEvent) => {
                this.imagem = e.target.result;
            }

            reader.readAsDataURL(input.files[0]);
        }

    }

    SalvarProduto(): void {

        const formData = new FormData();
        formData.append('Nome', this.nome)
        formData.append('Descricao', this.descricao)
        formData.append('ImagemProduto', this.files)

        fetch('api/Produto/SalvarProduto', {
            method: 'post',
            body: formData
        })
            .then(response => response.json())
            .then(data => {
                window.location.href="/produto/cadastrar"
            });

    }
}
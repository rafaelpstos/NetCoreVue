import Vue from 'vue';
import { Component } from 'vue-property-decorator';

interface FormData {
    getAll(): string[]
}

@Component({
    components: {
        MenuComponent: require('../navmenu/navmenu.vue.html')
    }
})
export default class ProdutoComponent extends Vue {

    nome: string = '';
    descricao: string = '';
    files: string = '';
    fileId = '';
    imagem: string = '';

    Upload(event: any): void {

        this.files = event.target.files[0]

        const formData = new FormData();
        formData.append('Files', event.target.files[0])

        fetch('api/Upload/UploadImage', {
            method: 'post',
            body: formData
        })
            .then(response => response.json())
            .then(data => {
                console.log('file id = ' + data)
                this.fileId = data;
                this.GetImage();
            });

    }

    GetImage(): void {
        var myHeaders = new Headers();

        var myInit = {
            method: 'GET',
            headers: myHeaders,
            mode: 'cors',
            cache: 'default'
        };

        fetch('api/Upload/GetImageId/?id=' + this.fileId, {
            method: 'GET',
            headers: myHeaders
        })
            .then(response => response.json())
            .then(result => {
                console.log('data = ' + result.data)
                this.imagem = 'data:image/png;base64,' + result.data
            });
    }

    SalvarProduto(): void {

        let dados = {
            Nome: this.nome,
            Descricao: this.descricao,
            ImagemProduto: this.imagem
        }

        fetch('api/Produto/SalvarProduto', {
            method: 'post',
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json',
            },
            body: JSON.stringify(dados)
        })
            .then(response => response.json())
            .then(data => {
                if (data.success) {
                    console.log(data);
                }
            });

    }
}
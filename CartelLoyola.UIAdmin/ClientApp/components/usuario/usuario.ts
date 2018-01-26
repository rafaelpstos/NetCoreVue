import Vue from 'vue';
import { Component } from 'vue-property-decorator';

interface Usuario {
    Id: number;
    Nome: string;
    Email: string;
    DataCadastro: string;
}

@Component({
    components: {
        MenuComponent: require('../navmenu/navmenu.vue.html')
    }
})
export default class UsuarioComponent extends Vue {
    user: Usuario[] = [];

    mounted() {
        fetch('api/Usuario/ObterTodos')
            .then(response => response.json() as Promise<Usuario[]>)
            .then(data => {
                this.user = data;
                console.log(data)
            });
    }
}

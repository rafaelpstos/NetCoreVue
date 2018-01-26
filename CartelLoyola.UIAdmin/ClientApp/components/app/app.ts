import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import * as a from '../../global'

@Component({
    components: {
        MenuComponent: require('../navmenu/navmenu.vue.html')
    }
})
export default class AppComponent extends Vue {
    username: string =  a.username
}

import Vue from 'vue';
import { Component, Prop } from 'vue-property-decorator';
import { Game } from '../models/Models';


@Component
export default class GameSelectionComponent extends Vue {
    selectedGame: Game = {
        name: '',
        jobs: []
    }

    allGames: Game[] = [];

    mounted() {
        fetch('http://localhost:53713/api/Game/')
            .then(response => response.json() as Promise<Game[]>)
            .then(data => { this.allGames = data });
    }

    SetGame() {
        this.$store.commit('selectGame', this.selectedGame);
        this.$router.push({name:'creation'}) //name given in boot.ts
    }

}
import Vue from 'vue';
import { Component } from 'vue-property-decorator';
import { Character, Caracteristic, Career } from '../models/Models';

@Component
export default class CharacterListComponent extends Vue {
    characters: Character[] = [];


    mounted() {
        fetch(`http://localhost:53713/api/Character/${this.$store.state.game}`)
            .then(response => response.json() as Promise<Character[]>)
            .then(data => {
                this.characters = data;
            });

        console.log(this.characters);
    }

        totalCharacters (this: any): number {
            return this.characters.length
        }
    

    deleteCharacter(characterName: string): void {
        console.log("delete " + characterName + " called");

        fetch(`http://localhost:53713/api/Character/${this.$store.state.game}/` + characterName, { method: 'delete' });
    }

}




import Vue from 'vue';
import { Component, Prop } from 'vue-property-decorator';
import { Character, Caracteristic, Career } from '../models/Models';

@Component
export default class CharacterDetailComponent extends Vue {
    @Prop({ type: String }) characterName: string;

    selectedCharacter: Character = {
        name: 'None chosen yet',
        gameName: 'none',
        baseAttributes: [],
        skills: [],
        stats: [],
        spendablePoints: [],
        profession: {
            name: '',
            jobSkills:[] 
        }
    }

    mounted() {
        console.log('Current character : '+this.characterName);
        console.log('Current game : ' + this.$store.state.game);
        fetch(`http://localhost:53713/api/Character/${this.$store.state.game.name}/` + this.characterName)
            .then(response => response.json() as Promise<Character>)
            .then(data => {
                this.selectedCharacter = data;
            });
    }


    GoToUpdate() {
        console.log('update');

        fetch(`http://localhost:53713/api/Character/${this.$store.state.game.name}/edit/` +this.selectedCharacter.name, {
            method: 'post',
            headers: {
                "Accept": "application/json",
                "Content-Type": "application/json"
            }, 
            body: JSON.stringify(this.selectedCharacter),
        })
        .then(data => console.log(data));

    }

}

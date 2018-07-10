import Vue from 'vue';
import { Component, Prop } from 'vue-property-decorator';
import { Character, Caracteristic, Career } from './Models';

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
        console.log(this.characterName);

        fetch('http://localhost:53713/api/FalloutCharacter/' + this.characterName)
            .then(response => response.json() as Promise<Character>)
            .then(data => {
                this.selectedCharacter = data;
            });
    }


    GoToUpdate() {
        console.log('update');
        //this.selectedCharacter.baseAttributes.forEach(function (x) {
        //    console.log("name : " + x.name + " score : " + x.score);
        //})



        fetch('http://locahost:53713/api/FalloutCharacter/edit',
            {
                method: 'post',
                body: JSON.stringify(this.selectedCharacter),
            }).then(data => console.log(data));

    }

}

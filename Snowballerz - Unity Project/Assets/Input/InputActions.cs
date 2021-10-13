// GENERATED AUTOMATICALLY FROM 'Assets/Input/InputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActions"",
    ""maps"": [
        {
            ""name"": ""Player_1"",
            ""id"": ""bc6965ac-fbbe-4ecc-acf5-55f221a7f861"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""7749e181-d91d-45d0-b97a-40ce027f50f7"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Action"",
                    ""type"": ""Button"",
                    ""id"": ""3c7d4992-dc05-4888-9e9a-6c3b1e7a7b9d"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Select"",
                    ""type"": ""Button"",
                    ""id"": ""b88afc21-9b65-4091-80d5-40475e7e2997"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Snowball"",
                    ""type"": ""Button"",
                    ""id"": ""1a0d8eb5-d9fc-4d5b-b176-69965c9fe973"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SelectDirection"",
                    ""type"": ""Value"",
                    ""id"": ""53afea95-a28f-4741-814f-903e34662ffd"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""6a87e6a5-618a-4f9e-9c37-eabcdc8f0eea"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""285624f3-f3da-4015-b2d3-06bedf0abaa6"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Arcade Controls"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""3c0b604c-992f-45ad-9192-49be3918dec4"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Arcade Controls"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""306be37c-4ca5-41fc-8c22-15ec11b5cdd2"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Arcade Controls"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""d4da727e-105e-4862-8858-ff6241caecac"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Arcade Controls"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""ed6de584-df17-410e-96a9-2b3fe4ba6361"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""fe69edb6-aad2-49d3-baa0-f5f25219efba"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Desktop"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""c32b7b51-3d5c-4422-9b3e-63491da66ee8"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Desktop"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""97e92cc5-e559-48a3-ac81-2a0eb7aa0ec3"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Desktop"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""c3fc09d8-1a1d-40be-88ca-d6d89646f8bd"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Desktop"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""79c64a33-e516-49a0-925f-0a0c7c3a51cd"",
                    ""path"": ""<Keyboard>/t"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Arcade Controls"",
                    ""action"": ""Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""58b142bb-3d8d-41b0-9a95-7637128f36b4"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Desktop"",
                    ""action"": ""Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""03640691-0baf-4593-a5ba-d3b8c39b67b7"",
                    ""path"": ""<Keyboard>/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Arcade Controls"",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""be00283f-bb03-4eaf-9a39-7ea06681665b"",
                    ""path"": ""<Keyboard>/t"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Desktop"",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f0c19a54-841c-4b60-b60f-b577e9473ebc"",
                    ""path"": ""<Keyboard>/u"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Arcade Controls"",
                    ""action"": ""Snowball"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""71a743ad-e7f0-459f-9150-a5e3ac16dfcc"",
                    ""path"": ""<Keyboard>/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Desktop"",
                    ""action"": ""Snowball"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""03332339-8421-4e16-9e9e-841d488bf432"",
                    ""path"": ""2DVector(mode=1)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SelectDirection"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""c12a7d7d-946a-4c11-9f1a-28167d64f880"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Desktop"",
                    ""action"": ""SelectDirection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""267a8fa0-ef2b-4523-9df9-65694ce57a22"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Desktop"",
                    ""action"": ""SelectDirection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""7a12808e-b194-43de-a9a7-c849920b4f90"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Desktop"",
                    ""action"": ""SelectDirection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""7b972d8f-6484-4e4d-aa83-1cbb62ac9adc"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Desktop"",
                    ""action"": ""SelectDirection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""ba5811be-5da0-4a7f-8dbd-0cd47cf51d13"",
                    ""path"": ""2DVector(mode=1)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Arcade Controls"",
                    ""action"": ""SelectDirection"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""94552048-b33f-4627-ba9b-41fc28a94b51"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Arcade Controls"",
                    ""action"": ""SelectDirection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""5dbb71e4-9c1c-4ccc-9b8f-ce0f9251945e"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Arcade Controls"",
                    ""action"": ""SelectDirection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""b34fcb84-6f3c-41cc-a980-e5a59bc05423"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Arcade Controls"",
                    ""action"": ""SelectDirection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""81739876-cafa-4cab-98bb-7e098252659a"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Arcade Controls"",
                    ""action"": ""SelectDirection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        },
        {
            ""name"": ""Player_2"",
            ""id"": ""67488c2e-be1a-49a5-9000-cfc849f68e7a"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""155cca28-2a15-4624-a399-0baf2b70ea85"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Action"",
                    ""type"": ""Button"",
                    ""id"": ""e5123439-01af-492c-a403-507e5f686bd2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Select"",
                    ""type"": ""Button"",
                    ""id"": ""29fbe409-100f-4fe1-9767-4cc5c6d96a9a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Snowball"",
                    ""type"": ""Button"",
                    ""id"": ""2e1dc9f1-e790-4034-a622-330bf2f3fde0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SelectDirection"",
                    ""type"": ""Value"",
                    ""id"": ""d11d301c-fbdc-4eba-accc-67bfcbb704a3"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""8ce5f11c-61e4-4ad5-88f6-41242bf54b8a"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""9d9051da-74cc-47e0-a8e5-fb03b8431f66"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Arcade Controls"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""02d0e513-e9a6-498b-ba3b-d43f31823fa5"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Arcade Controls"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""2c0209f4-20ea-4014-ac45-9474f7c665e1"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Arcade Controls"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""e877d9a5-cc94-4369-8dd1-2743801eee0d"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Arcade Controls"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""39b0af62-0f67-42a6-883e-45e9259fd86d"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""3ed3673b-bfa9-4aa7-9bef-6a4e97bf2d24"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Desktop"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""09190728-2ce6-4a05-82c8-1811218a493e"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Desktop"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""27cca4e9-44f7-4b25-adab-5478eaa2d2d1"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Desktop"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""9c13925d-cec7-4750-b27d-69909acce709"",
                    ""path"": ""<Keyboard>/l"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Desktop"",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""f746aecb-a6d5-450b-80f5-649940339921"",
                    ""path"": ""<Keyboard>/numpad1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Arcade Controls"",
                    ""action"": ""Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""14488d4e-223f-4f37-8c1e-b619261f72ea"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Desktop"",
                    ""action"": ""Action"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""80571769-e068-43b7-b609-b553fa2dff1a"",
                    ""path"": ""<Keyboard>/numpad2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Arcade Controls"",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e9d26429-a9f0-438d-b237-cc9b7ca3066f"",
                    ""path"": ""<Keyboard>/leftBracket"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Desktop"",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f0f58a96-2417-4665-a47a-da0671969779"",
                    ""path"": ""<Keyboard>/numpad3"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Arcade Controls"",
                    ""action"": ""Snowball"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5f01e6a1-8495-4715-9a0b-8c5a360c1616"",
                    ""path"": ""<Keyboard>/rightBracket"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Desktop"",
                    ""action"": ""Snowball"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""fee7cab8-0b57-4071-a165-58e59ef6beda"",
                    ""path"": ""2DVector(mode=1)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Desktop"",
                    ""action"": ""SelectDirection"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""8640361a-9f0c-4983-895a-6cb3f54971c3"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Desktop"",
                    ""action"": ""SelectDirection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""5fd73d8b-65b3-478c-8daf-a52c374a4d85"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Desktop"",
                    ""action"": ""SelectDirection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""f705ac75-d330-4cc4-9a91-4f0905ee10c2"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Desktop"",
                    ""action"": ""SelectDirection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""9b448a63-b095-4de3-9727-c1474bb25f70"",
                    ""path"": ""<Keyboard>/l"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Desktop"",
                    ""action"": ""SelectDirection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""a1ade1fa-1251-42c2-ba2c-c72c4a9d583a"",
                    ""path"": ""2DVector(mode=1)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Arcade Controls"",
                    ""action"": ""SelectDirection"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""d36945a0-2769-4165-b78e-11829367ee3a"",
                    ""path"": ""<Keyboard>/i"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Arcade Controls"",
                    ""action"": ""SelectDirection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""fab63bcc-9619-4127-853e-d76b58603e3f"",
                    ""path"": ""<Keyboard>/k"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Arcade Controls"",
                    ""action"": ""SelectDirection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""68500928-f13e-4f7a-a4a8-c24557c9d22f"",
                    ""path"": ""<Keyboard>/j"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Arcade Controls"",
                    ""action"": ""SelectDirection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""18055760-0c05-46c4-bb45-2634fdc66b4d"",
                    ""path"": ""<Keyboard>/l"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Arcade Controls"",
                    ""action"": ""SelectDirection"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Arcade Controls"",
            ""bindingGroup"": ""Arcade Controls"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Desktop"",
            ""bindingGroup"": ""Desktop"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Player_1
        m_Player_1 = asset.FindActionMap("Player_1", throwIfNotFound: true);
        m_Player_1_Move = m_Player_1.FindAction("Move", throwIfNotFound: true);
        m_Player_1_Action = m_Player_1.FindAction("Action", throwIfNotFound: true);
        m_Player_1_Select = m_Player_1.FindAction("Select", throwIfNotFound: true);
        m_Player_1_Snowball = m_Player_1.FindAction("Snowball", throwIfNotFound: true);
        m_Player_1_SelectDirection = m_Player_1.FindAction("SelectDirection", throwIfNotFound: true);
        // Player_2
        m_Player_2 = asset.FindActionMap("Player_2", throwIfNotFound: true);
        m_Player_2_Move = m_Player_2.FindAction("Move", throwIfNotFound: true);
        m_Player_2_Action = m_Player_2.FindAction("Action", throwIfNotFound: true);
        m_Player_2_Select = m_Player_2.FindAction("Select", throwIfNotFound: true);
        m_Player_2_Snowball = m_Player_2.FindAction("Snowball", throwIfNotFound: true);
        m_Player_2_SelectDirection = m_Player_2.FindAction("SelectDirection", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Player_1
    private readonly InputActionMap m_Player_1;
    private IPlayer_1Actions m_Player_1ActionsCallbackInterface;
    private readonly InputAction m_Player_1_Move;
    private readonly InputAction m_Player_1_Action;
    private readonly InputAction m_Player_1_Select;
    private readonly InputAction m_Player_1_Snowball;
    private readonly InputAction m_Player_1_SelectDirection;
    public struct Player_1Actions
    {
        private @InputActions m_Wrapper;
        public Player_1Actions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Player_1_Move;
        public InputAction @Action => m_Wrapper.m_Player_1_Action;
        public InputAction @Select => m_Wrapper.m_Player_1_Select;
        public InputAction @Snowball => m_Wrapper.m_Player_1_Snowball;
        public InputAction @SelectDirection => m_Wrapper.m_Player_1_SelectDirection;
        public InputActionMap Get() { return m_Wrapper.m_Player_1; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Player_1Actions set) { return set.Get(); }
        public void SetCallbacks(IPlayer_1Actions instance)
        {
            if (m_Wrapper.m_Player_1ActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_Player_1ActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_Player_1ActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_Player_1ActionsCallbackInterface.OnMove;
                @Action.started -= m_Wrapper.m_Player_1ActionsCallbackInterface.OnAction;
                @Action.performed -= m_Wrapper.m_Player_1ActionsCallbackInterface.OnAction;
                @Action.canceled -= m_Wrapper.m_Player_1ActionsCallbackInterface.OnAction;
                @Select.started -= m_Wrapper.m_Player_1ActionsCallbackInterface.OnSelect;
                @Select.performed -= m_Wrapper.m_Player_1ActionsCallbackInterface.OnSelect;
                @Select.canceled -= m_Wrapper.m_Player_1ActionsCallbackInterface.OnSelect;
                @Snowball.started -= m_Wrapper.m_Player_1ActionsCallbackInterface.OnSnowball;
                @Snowball.performed -= m_Wrapper.m_Player_1ActionsCallbackInterface.OnSnowball;
                @Snowball.canceled -= m_Wrapper.m_Player_1ActionsCallbackInterface.OnSnowball;
                @SelectDirection.started -= m_Wrapper.m_Player_1ActionsCallbackInterface.OnSelectDirection;
                @SelectDirection.performed -= m_Wrapper.m_Player_1ActionsCallbackInterface.OnSelectDirection;
                @SelectDirection.canceled -= m_Wrapper.m_Player_1ActionsCallbackInterface.OnSelectDirection;
            }
            m_Wrapper.m_Player_1ActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Action.started += instance.OnAction;
                @Action.performed += instance.OnAction;
                @Action.canceled += instance.OnAction;
                @Select.started += instance.OnSelect;
                @Select.performed += instance.OnSelect;
                @Select.canceled += instance.OnSelect;
                @Snowball.started += instance.OnSnowball;
                @Snowball.performed += instance.OnSnowball;
                @Snowball.canceled += instance.OnSnowball;
                @SelectDirection.started += instance.OnSelectDirection;
                @SelectDirection.performed += instance.OnSelectDirection;
                @SelectDirection.canceled += instance.OnSelectDirection;
            }
        }
    }
    public Player_1Actions @Player_1 => new Player_1Actions(this);

    // Player_2
    private readonly InputActionMap m_Player_2;
    private IPlayer_2Actions m_Player_2ActionsCallbackInterface;
    private readonly InputAction m_Player_2_Move;
    private readonly InputAction m_Player_2_Action;
    private readonly InputAction m_Player_2_Select;
    private readonly InputAction m_Player_2_Snowball;
    private readonly InputAction m_Player_2_SelectDirection;
    public struct Player_2Actions
    {
        private @InputActions m_Wrapper;
        public Player_2Actions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Player_2_Move;
        public InputAction @Action => m_Wrapper.m_Player_2_Action;
        public InputAction @Select => m_Wrapper.m_Player_2_Select;
        public InputAction @Snowball => m_Wrapper.m_Player_2_Snowball;
        public InputAction @SelectDirection => m_Wrapper.m_Player_2_SelectDirection;
        public InputActionMap Get() { return m_Wrapper.m_Player_2; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(Player_2Actions set) { return set.Get(); }
        public void SetCallbacks(IPlayer_2Actions instance)
        {
            if (m_Wrapper.m_Player_2ActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_Player_2ActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_Player_2ActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_Player_2ActionsCallbackInterface.OnMove;
                @Action.started -= m_Wrapper.m_Player_2ActionsCallbackInterface.OnAction;
                @Action.performed -= m_Wrapper.m_Player_2ActionsCallbackInterface.OnAction;
                @Action.canceled -= m_Wrapper.m_Player_2ActionsCallbackInterface.OnAction;
                @Select.started -= m_Wrapper.m_Player_2ActionsCallbackInterface.OnSelect;
                @Select.performed -= m_Wrapper.m_Player_2ActionsCallbackInterface.OnSelect;
                @Select.canceled -= m_Wrapper.m_Player_2ActionsCallbackInterface.OnSelect;
                @Snowball.started -= m_Wrapper.m_Player_2ActionsCallbackInterface.OnSnowball;
                @Snowball.performed -= m_Wrapper.m_Player_2ActionsCallbackInterface.OnSnowball;
                @Snowball.canceled -= m_Wrapper.m_Player_2ActionsCallbackInterface.OnSnowball;
                @SelectDirection.started -= m_Wrapper.m_Player_2ActionsCallbackInterface.OnSelectDirection;
                @SelectDirection.performed -= m_Wrapper.m_Player_2ActionsCallbackInterface.OnSelectDirection;
                @SelectDirection.canceled -= m_Wrapper.m_Player_2ActionsCallbackInterface.OnSelectDirection;
            }
            m_Wrapper.m_Player_2ActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Action.started += instance.OnAction;
                @Action.performed += instance.OnAction;
                @Action.canceled += instance.OnAction;
                @Select.started += instance.OnSelect;
                @Select.performed += instance.OnSelect;
                @Select.canceled += instance.OnSelect;
                @Snowball.started += instance.OnSnowball;
                @Snowball.performed += instance.OnSnowball;
                @Snowball.canceled += instance.OnSnowball;
                @SelectDirection.started += instance.OnSelectDirection;
                @SelectDirection.performed += instance.OnSelectDirection;
                @SelectDirection.canceled += instance.OnSelectDirection;
            }
        }
    }
    public Player_2Actions @Player_2 => new Player_2Actions(this);
    private int m_ArcadeControlsSchemeIndex = -1;
    public InputControlScheme ArcadeControlsScheme
    {
        get
        {
            if (m_ArcadeControlsSchemeIndex == -1) m_ArcadeControlsSchemeIndex = asset.FindControlSchemeIndex("Arcade Controls");
            return asset.controlSchemes[m_ArcadeControlsSchemeIndex];
        }
    }
    private int m_DesktopSchemeIndex = -1;
    public InputControlScheme DesktopScheme
    {
        get
        {
            if (m_DesktopSchemeIndex == -1) m_DesktopSchemeIndex = asset.FindControlSchemeIndex("Desktop");
            return asset.controlSchemes[m_DesktopSchemeIndex];
        }
    }
    public interface IPlayer_1Actions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnAction(InputAction.CallbackContext context);
        void OnSelect(InputAction.CallbackContext context);
        void OnSnowball(InputAction.CallbackContext context);
        void OnSelectDirection(InputAction.CallbackContext context);
    }
    public interface IPlayer_2Actions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnAction(InputAction.CallbackContext context);
        void OnSelect(InputAction.CallbackContext context);
        void OnSnowball(InputAction.CallbackContext context);
        void OnSelectDirection(InputAction.CallbackContext context);
    }
}

import { ArEnumEncoding2 } from '#/Enums'

export const formatterOptions = [
  { label: 'Shift-JIS', value: ArEnumEncoding2.SHIFT_JIS },
  { label: 'UTF-8(BOM付)', value: ArEnumEncoding2.UTF8 },
  { label: 'UTF-8(BOM無)', value: ArEnumEncoding2.UTF8 + 1 },
  { label: 'UTF-16LE(BOM付)', value: ArEnumEncoding2.UTF16_LE + 1 },
  { label: 'UTF-16LE(BOM無)', value: ArEnumEncoding2.UTF16_LE + 2 },
  { label: 'UTF-16BE(BOM付)', value: ArEnumEncoding2.UTF16_BE + 2 },
  { label: 'UTF-16BE(BOM無)', value: ArEnumEncoding2.UTF16_BE + 3 }
]
